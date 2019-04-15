using System;
using System.Collections.Generic;
using System.Text;

namespace QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts
{
    public interface IQueuePublishRepo
    {
        bool PublishMessage(string message);
    }
}
