using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqSend.ExchangeDemo
{
   public static class DirectExchange
    {
        public static void Publish(IModel channel)
        {
            var timetolive=new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("direct-exchange",ExchangeType.Direct,arguments:timetolive);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Direct Exchange Producer", Message = $"RabbitMQ Direct Exchange.My order {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("direct-exchange", "payment.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
           
        }
    }
}
