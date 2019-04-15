using QueuePublisher.Interface.Contracts;
using QueuePublisher.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QueuePublisher.Test
{
    public class ValidationTest
    {
        IValidationService validationService;
        public ValidationTest()
        {
            validationService = new ValidationService();
        }

        [Fact]
        public void TestMessageIsNotEmpty()
        {
            Assert.True(validationService.ValidateMessage("Test"));
        }

        [Fact]
        public void TestMessageIsEmpty()
        {
            Assert.False(validationService.ValidateMessage(""));
        }


    }
}
