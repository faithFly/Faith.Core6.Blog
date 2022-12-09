using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost"
            };
            //get rabbitmq connection
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //coster
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    //get message
                    consumer.Received += (ch, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine($"收到消息：{message}");
                        //Identify spending
                        channel.BasicAck(ea.DeliveryTag, false);
                    };
                    channel.BasicConsume("hello1", false, consumer);
                    Console.WriteLine("消费者1已启动");
                    Console.ReadKey();
                }
            }
        }
    }
}