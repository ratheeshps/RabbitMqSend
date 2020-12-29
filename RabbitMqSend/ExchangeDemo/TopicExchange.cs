using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqSend.ExchangeDemo
{
    public static class TopicExchange
    {
        public static void Publish(IModel channel)
        {
            var timetolive = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("topic-exchange", ExchangeType.Topic,arguments: timetolive);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Topic Exchange Producer", Message = $"RabbitMQ Topic Exchange.My order {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("topic-exchange", "user.update", null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}
