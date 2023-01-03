using Hangfire;

namespace Faith.Core6.HangFire
{
    public class HangFireConnectionString
    {
        public static string connectionString { get; set; }
        public static int db { get; set; } = 0;
        public static JobStorage hangfireStorage;
    }
}