using Microsoft.Extensions.DependencyInjection;
using QueuePublisher.Interface.Contracts.PublishService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QueuePublisher
{
    class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceHost();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Please enter your name: ");
                    string message = Console.ReadLine();
                    serviceProvider.GetService<IPublishService>().Publish(message);
                }
            });
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();

        }
        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");            
            _closing.Set();
            Environment.Exit(0);
        }

        private static IServiceProvider BuildServiceHost()
        {
            var services = new Startup().ConfigureServices(new ServiceCollection());

            return services.BuildServiceProvider();
        }


    }
}
