using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.Redis;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.JWT;
using Faith.EntityModel.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class LoginUserService : ILoginUserService
    {
        private readonly faithdbContext _client;
        private readonly JWTHelper jWTHelper;
        private readonly IRedisClient _redis;
        private readonly IOptions<RedisConfig> _settings;
        public LoginUserService(faithdbContext _client,
            JWTHelper jWTHelper,
            IRedisClient _redis,
            IOptions<RedisConfig> _settings
            )
        {
            this._client = _client;
            this.jWTHelper = jWTHelper;
            this._redis = _redis;
            this._settings = _settings;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<ResultDto<User>> GetLoginUser(UserLoginDto userLogin) {
            Console.WriteLine(_settings);
            if (string.IsNullOrEmpty(userLogin.UserName)||string.IsNullOrEmpty(userLogin.UserPassWord))
            {
                return new ResultDto<User>
                {
                    ResultCode = 500,
                    ResultMsg = "用户名密码不能为空"
                };
            }
            //Md5加密...
            string Md5Pwd = "";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(userLogin.UserPassWord));
                var strResult = BitConverter.ToString(result);
                Md5Pwd = strResult.Replace("-", "");

            }
            var userObj =await _client.Users.Where(p => p.UserName == userLogin.UserName && p.UserPassWord == Md5Pwd).SingleOrDefaultAsync();
            if (userObj==null)
            {
                throw new UserFriendlyException(404, "用户不存在!");
            }
            else
            {
                T_Log log = new T_Log
                {
                    Id = Guid.NewGuid().ToString(),
                    LogMessage = "登录成功！",
                    CreateBy = userObj.UserName,
                    CreateTime = DateTime.Now
                };
                await _client.T_Logs.AddAsync(log);
                await _client.SaveChangesAsync();
                //token
                var token = jWTHelper.CreatToken(userObj.Id,userObj.UserName);
                //redis 存储
                _redis.Set("FaithWeb:login:token",token,TimeSpan.FromDays(7));
                return new ResultDto<User>
                {
                    ResultCode = 200,
                    ResultMsg = token
                };
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ResultDto<User>> RegistUserAsync(User user)
        {
            var userObj = await _client.Users.Where(p => p.UserName == user.UserName).SingleOrDefaultAsync();
            if (userObj!=null)
            {
                throw new UserFriendlyException(404, "该用户已经存在");
            }
            string Md5Pwd = "";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassWord));
                var strResult = BitConverter.ToString(result);
                Md5Pwd = strResult.Replace("-", "");
                user.UserPassWord = Md5Pwd;
            }
            user.Id = Guid.NewGuid().ToString();
            user.CreateTime = DateTime.Now;
            user.UpdateTime = DateTime.Now;
            await _client.Users.AddAsync(user);
            var flag =await _client.SaveChangesAsync();
            if (flag>0)
            {
                return new ResultDto<User>
                {
                    ResultCode = 200
                };
            }
            else
            {
                throw new UserFriendlyException(500, "插入失败！");
            }
        }
    }
}
