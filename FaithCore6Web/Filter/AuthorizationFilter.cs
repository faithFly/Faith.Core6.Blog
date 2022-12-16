using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FaithCore6Web.Filter
{
    public class AuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //将token信息存储到分布式缓存
            base.OnAuthorization(actionContext);
        }
    }
}
