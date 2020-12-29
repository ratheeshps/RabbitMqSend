using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqSend.BasicDemo
{
   public  class BasicQueue
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("demo-queue", true, false, false, arguments: null);
            var message = new { Name = "Basic Producer", Message = "Howdy RabbitMQ" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "demo-queue", null, body);
        }
    }
}
