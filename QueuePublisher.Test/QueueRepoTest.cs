using QueuePublisher.Infrastructure.Repositories.QueueRepo;
using QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts;
using System;
using Xunit;

namespace QueuePublisher.Test
{
    public class QueueRepoTest
    {
        IQueuePublishRepo queueRepo;
        public QueueRepoTest()
        {
            queueRepo = new FakeRabbitRepo();
        }

        [Fact]
        public void TestQueuePublishSuccessful()
        {
            Assert.True(queueRepo.PublishMessage("Test Message"));

        }
    }
}
