using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Domain.UserSession
{
    public class FaithUserSession : IFaithUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FaithUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserName() {
            var http = _httpContextAccessor.HttpContext;
            var userName = http.User?.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.Name);
            return userName?.Value;
        }
    }
}
