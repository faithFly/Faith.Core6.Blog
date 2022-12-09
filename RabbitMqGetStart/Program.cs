using RabbitMQ.Client;
using System.Text;

namespace RabbitMqGetStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //生产者
            //创建连接工厂
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                //创建通道
                using (var channel =connection.CreateModel())
                {
                    //声明一个队列
                    channel.QueueDeclare("hello1", false, false, false, null);
                    //如果没有声明交换机，队列会自动绑定到默认direct类型的交换机，并以队列的形式作为路由键
                    Console.WriteLine("rabbitmq连接成功！请输入消息！exit退出！");
                    string input;
                    do
                    {
                        input = Console.ReadLine();
                        var sendBytes = Encoding.UTF8.GetBytes(input);
                        //发布消息
                        channel.BasicPublish("", "hello1", null, sendBytes);
                    } while (input.Trim().ToLower()!="exit");
                }
            }
        }
    }
}