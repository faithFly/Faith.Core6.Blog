using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto.ExceptionDto
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException()
        {
        }
        public int Code { get; set; }
        public UserFriendlyException(int code, string message)
        : base(message)
        {
            Code = code;
        }
    }
}
