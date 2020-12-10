using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMqSend
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserName = "guest";

            string Password = "guest";

            string HostName = "localhost";

            //Main entry point to the RabbitMQ .NET AMQP client

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()

            {

                UserName = UserName,

                Password = Password,

                HostName = HostName

            };
            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();
          //  model.QueueBind("CinqueQue", "demoExchange", "directexchange_key");




            var properties = model.CreateBasicProperties();

            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message");

            model.BasicPublish("Cinque", "directexchange_key", properties, messagebuffer);

            Console.WriteLine("Message Sent");

            Console.ReadLine();
        }
    }
}
