using QueuePublisher.Infrastructure.Repositories.QueueRepo;
using QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts;
using QueuePublisher.Interface.Contracts;
using QueuePublisher.Interface.Contracts.PublishService;

namespace QueuePublisher.Service.Services
{
    public class PublishService : IPublishService
    {
        private readonly IQueuePublishRepo _queuePublishRepo;
        private readonly IValidationService _validationService;

        public PublishService(IQueuePublishRepo queuePublishRepo, IValidationService validationService)
        {
            _queuePublishRepo = queuePublishRepo;
            _validationService = validationService;
        }

        public void Publish(string message)
        {
            _queuePublishRepo.PublishMessage(ConvertNameToPhrase(message));
        }

        private string ConvertNameToPhrase(string message)
        {
            return _validationService.ValidateMessage(message) ? $"Hello my name is, {message}" : "Please enter a name.";
           
        }
    }
}
