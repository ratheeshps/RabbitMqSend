using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqSend.ExchangeDemo
{
    public static class FanoutExchange
    {
        public static void Publish(IModel channel)
        {
            var timetolive = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("fanout-exchange", ExchangeType.Fanout, arguments: timetolive);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Fanout Exchange Producer", Message = $"RabbitMQ Fanout Exchange.My order {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var properties = channel.CreateBasicProperties();
              
                channel.BasicPublish("fanout-exchange","account.update",null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}
