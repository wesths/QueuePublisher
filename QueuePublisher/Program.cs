using Microsoft.Extensions.DependencyInjection;
using QueuePublisher.Interface.Contracts.PublishService;
using QueuePublisher.Service.PublishService;
using System;

namespace QueuePublisher
{
    class Program
    {
      

        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceHost();

            while (true)
            {

                Console.WriteLine("Please enter your name or type [exit] to exit application. ");
                string message = Console.ReadLine();
                if (message == "exit") // Check string
                {
                    Console.WriteLine("Exitting...");
                    Environment.Exit(-1);
                }
                serviceProvider.GetService<IPublishService>().Publish(message);
            }
            
        }

        private static IServiceProvider BuildServiceHost()
        {
            var services = new Startup().ConfigureServices(new ServiceCollection());

            return services.BuildServiceProvider();
        }


    }
}
