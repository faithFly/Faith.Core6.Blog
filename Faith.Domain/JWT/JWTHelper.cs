using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Domain.JWT
{
    public class JWTHelper
    {
        private readonly IConfiguration _configuration;
        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 创建token
        /// </summary>
        /// <returns></returns>
        public string CreatToken(string id, string userName)
        {
            // 1. 定义需要使用到的Claims
            var claims = new[] {
                new Claim("id",id),
                new Claim("userName",userName)
            };
            //2.从application.json中读取密钥
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            //3.选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;
            //4.生成Credentials证书 将密码和算法带入
            var signCredentials = new SigningCredentials(secretKey, algorithm);
            //5.生成token
            var jwtSecretToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],     //Issuer
                _configuration["Jwt:Audience"],   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddSeconds(30),    //expires
                signCredentials               //Credentials
                );
            // 6. 将token变为string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecretToken);
            return token;
        }

    }
}
