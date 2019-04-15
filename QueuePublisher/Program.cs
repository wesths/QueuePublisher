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

            //while (!Console.ReadLine().Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            //{
            //    Console.WriteLine("Please enter your name or type [exit] to exit application. ");
            //    serviceProvider.GetService<IPublishService>().Publish(Console.ReadLine());
            //}

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Please enter your name or type [exit] to exit application. ");
                    string message = Console.ReadLine();
                    serviceProvider.GetService<IPublishService>().Publish(message);
                    Thread.Sleep(1000);
                }
            });
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();

            //while (true)
            //{

            //    Console.WriteLine("Please enter your name or type [exit] to exit application. ");
            //    string message = Console.ReadLine();
            //    if (message == "exit") // Check string
            //    {
            //        Console.WriteLine("Exitting...");
            //        Environment.Exit(-1);
            //    }
            //    serviceProvider.GetService<IPublishService>().Publish(message);
            //}

        }
        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            _closing.Set();
        }

        private static IServiceProvider BuildServiceHost()
        {
            var services = new Startup().ConfigureServices(new ServiceCollection());

            return services.BuildServiceProvider();
        }


    }
}
