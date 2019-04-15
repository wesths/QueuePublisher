using QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueuePublisher.Infrastructure.Repositories.QueueRepo
{
    public class FakeRabbitRepo : IQueuePublishRepo
    {
        public bool PublishMessage(string message)
        {
            return true;
        }
    }
}
