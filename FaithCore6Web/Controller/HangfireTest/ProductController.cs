using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithCore6Web.Controller.HangfireTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public string Login() {
            //这个任务就执行一次
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("welcome to my home"));
            return $"jobId is {jobId},hello world";
        }
        [HttpGet]
        [Route("productcheckout")]
        public string CheckoutProduct() {
            //这项工作只执行了一次，但过了一段时间后不会立即执行。
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"),TimeSpan.FromSeconds(20));
            return $"jobId is {jobId}";
        }
        [HttpGet]
        [Route("productpayment")]
        public String ProductPayment()
        {
            //Fire and Forget Job - this job is executed only once
            var parentjobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));

            //Continuations Job - 此作业在其父作业执行时执行。
            BackgroundJob.ContinueJobWith(parentjobId, () => Console.WriteLine("Product receipt sent!"));

            return "You have done payment and receipt sent on your mail id!";
        }
        [HttpGet]
        [Route("dailyoffers")]
        public String DailyOffers()
        {
            //Recurring Job - this job is executed many times on the specified cron schedule
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Daily);

            return "offer sent!";
        }
    }
}
