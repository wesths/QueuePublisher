using QueuePublisher.Infrastructure.Repositories.QueueRepo.Contracts;
using QueuePublisher.Interface.Contracts;
using QueuePublisher.Interface.Contracts.PublishService;
using System;

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
            if (_validationService.ValidateMessage(message))
            {
                _queuePublishRepo.PublishMessage(ConvertNameToPhrase(message));
                Console.WriteLine($"Name: {message} sent to Rabbit");
            }
            else
            {
                Console.WriteLine("Please enter a name.");
            }
        }

        private string ConvertNameToPhrase(string message)
        {
            return $"Hello my name is, {message}";           
        }
    }
}
