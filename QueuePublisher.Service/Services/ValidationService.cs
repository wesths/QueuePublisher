using QueuePublisher.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueuePublisher.Service.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateMessage(string message)
        {
            return !string.IsNullOrEmpty(message);            
        }
    }
}
