using System;
using System.Collections.Generic;
using System.Text;

namespace QueuePublisher.Interface.Contracts
{
    public interface IValidationService
    {
        bool ValidateMessage(string message);
    }
}
