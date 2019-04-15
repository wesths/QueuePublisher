using Microsoft.Extensions.Configuration;
using QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts;
using RabbitMQ.Client;
using System;
using System.Text;

namespace QueuePublisher.Infrastructure.Repositories.QueueRepo
{
    public class RabbitRepo : IQueuePublishRepo
    {
        private readonly IConfiguration _configuration;
        private IConnection conn = null;
        private IModel channel = null;

        public RabbitRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = CreateConnectionFactory();
            channel = conn.CreateModel();
            channel.QueueDeclare(_configuration.GetSection("AppSettings:QueueName").Value, true, false, false, null);
        }

        private IConnection CreateConnectionFactory()
        {
            var factory = new ConnectionFactory()
            {
                // "guest"/"guest" by default, limited to localhost connections
                UserName = _configuration.GetSection("AppSettings:QueueUser").Value,
                Password = _configuration.GetSection("AppSettings:QueuePassword").Value,
                HostName = _configuration.GetSection("AppSettings:QueueHostName").Value
            };

            conn = factory.CreateConnection();
            
            return conn;
        }

        public bool PublishMessage(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", _configuration.GetSection("AppSettings:QueueName").Value, null, messageBytes);            
            return true;
        }
    }
}
