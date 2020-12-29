using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMqSend.BasicDemo;
using RabbitMqSend.ExchangeDemo;
using System;
using System.Text;

namespace RabbitMqSend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am a RabbitMQ Producer. Environment friendly :D ");

            string UserName = "guest";
            string Password = "guest";
            string HostName = "localhost";

            //Main entry point to the RabbitMQ .NET AMQP client
            #region "Connection and Initialization"
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()

            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel(); //Create a channel

            #endregion

            #region "Basic Demo"
           // BasicQueue.Publish(channel);
            #endregion

            #region "Exchange Demo"
           // DirectExchange.Publish(channel);
            #endregion

            #region "Topic Demo"
            //TopicExchange.Publish(channel);
            #endregion

            #region "Header Demo"
         //   HeaderExchange.Publish(channel);
            #endregion

            #region "Fanout Demo"
            FanoutExchange.Publish(channel);
            #endregion

            Console.ReadKey();
        }
    }
}
//test