using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqSend.ExchangeDemo
{
    public static class HeaderExchange
    {
        public static void Publish(IModel channel)
        {
            var timetolive = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("header-exchange", ExchangeType.Headers, arguments: timetolive);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Header Exchange Producer", Message = $"RabbitMQ Header Exchange.My order {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object>
                {
                    {"account","new" }, 
                    {"account","update" },
                    {"account","delete" }
                };
                channel.BasicPublish("header-exchange-queue", string.Empty, properties, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}
