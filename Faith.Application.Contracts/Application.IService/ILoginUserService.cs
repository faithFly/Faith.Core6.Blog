using Faith.Application.Contracts.Application.Dto;
using Faith.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService
{
    public interface ILoginUserService
    {
        Task<ResultDto<User>> GetLoginUser(UserLoginDto userLogin);
        Task<ResultDto<User>> RegistUserAsync(User user);
    }
}
