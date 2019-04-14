using System;
using System.Collections.Generic;
using System.Text;

namespace QueuePublisher.Interface.Contracts.PublishService
{
    public interface IPublishService
    {
        void Publish(string message);
    }
}
