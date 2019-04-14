using QueuePublisher.Infrastructure.Repositories.QueueRepo;
using QueuePublisher.Interface.Contracts.PublishService;

namespace QueuePublisher.Service.PublishService
{
    public class PublishService : IPublishService
    {
        private readonly IQueuePublishRepo _queuePublishRepo;

        public PublishService(IQueuePublishRepo queuePublishRepo)
        {
            _queuePublishRepo = queuePublishRepo;
        }

        public void Publish(string message)
        {
            _queuePublishRepo.PublishMessage(ConvertNameToPhrase(message));
        }

        private string ConvertNameToPhrase(string message)
        {
            return $"Hello my name is, {message}";
        }
    }
}
