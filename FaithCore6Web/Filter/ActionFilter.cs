using Faith.DbMigrator.Faith.Dbcontext;
using Faith.EntityModel.Entity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FaithCore6Web.Filter
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
/*            string ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            UserLog log = new UserLog();
            log.Id = Guid.NewGuid().ToString();
            log.Arr02 = ipaddress;
            log.Arr01 = "111";
            log.CreateTime = DateTime.Now;
            _faithdbContext.UserLog.Add(log);
            _faithdbContext.SaveChanges();*/
            Console.WriteLine("hello");
        }
    }
}
