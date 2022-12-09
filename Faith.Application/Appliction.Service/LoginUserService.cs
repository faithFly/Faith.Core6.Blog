﻿using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.IService;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.JWT;
using Faith.EntityModel.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class LoginUserService : ILoginUserService
    {
        private readonly faithdbContext _client;
        private readonly JWTHelper jWTHelper;
        public LoginUserService(faithdbContext _client,JWTHelper jWTHelper)
        {
            this._client = _client;
            this.jWTHelper = jWTHelper;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<ResultDto<User>> GetLoginUser(UserLoginDto userLogin) {
            if (string.IsNullOrEmpty(userLogin.UserName)||string.IsNullOrEmpty(userLogin.UserPassWord))
            {
                return new ResultDto<User>
                {
                    ResultCode = 500,
                    ResultMsg = "用户名密码不能为空"
                };
            }
            //Md5加密...
            var userObj =await _client.Users.Where(p => p.UserName == userLogin.UserName && p.UserPassWord == userLogin.UserPassWord).SingleOrDefaultAsync();
            if (userObj==null)
            {
                return new ResultDto<User>
                {
                    ResultCode = 500,
                    ResultMsg ="未查到改用户"
                };
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
                return new ResultDto<User>
                {
                    ResultCode = 500,
                    ResultMsg = "该用户已经存在！"
                };
            }
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
                return new ResultDto<User>
                {
                    ResultCode = 500
                };
            }
        }
    }
}