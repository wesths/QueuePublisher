using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueuePublisher.Infrastructure.Repositories.QueueRepo;
using QueuePublisher.Interface.Contracts.PublishService;
using QueuePublisher.Service.PublishService;
using System.IO;

namespace QueuePublisher
{
    public class Startup
    {
        
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        internal IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<IQueuePublishRepo, RabbitRepo>();
            services.AddTransient<IPublishService, PublishService>();

            return services;

        }        
    }
}
