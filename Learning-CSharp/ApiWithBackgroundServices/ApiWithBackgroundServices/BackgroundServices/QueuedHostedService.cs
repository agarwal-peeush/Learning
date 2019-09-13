using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithBackgroundServices.BackgroundServices
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly ILogger _Logger;

        public QueuedHostedService(IBackgroundTaskQueue taskQueue, ILoggerFactory loggerFactory)
        {
            TaskQueue = taskQueue;
            _Logger = loggerFactory.CreateLogger<QueuedHostedService>();
        }

        public IBackgroundTaskQueue TaskQueue { get; }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _Logger.LogInformation("Queued Hosted Service is starting.");

            while (!cancellationToken.IsCancellationRequested)
            {
                var workItem = await TaskQueue.DequeueAsync(cancellationToken);

                try
                {
                    await workItem(cancellationToken);
                }
                catch (Exception ex)
                {
                    _Logger.LogError(ex,
                       $"Error occurred executing {nameof(workItem)}.");
                }
            }

            _Logger.LogInformation("Queued Hosted Service is stopping.");
        }
    }
}
