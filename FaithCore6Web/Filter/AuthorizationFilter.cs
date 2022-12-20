using Faith.Core6.Redis;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FaithCore6Web.Filter
{
    public class AuthorizationFilter : AuthorizationFilterAttribute
    {
        private readonly IRedisClient client;

        public AuthorizationFilter(IRedisClient client)
        {
            this.client = client;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //将token信息存储到分布式缓存
            Console.WriteLine(1);
        }
    }
}
