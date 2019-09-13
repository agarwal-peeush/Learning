using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithBackgroundServices.BackgroundServices
{
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private ConcurrentQueue<Func<CancellationToken, Task>> _WorkItems =
            new ConcurrentQueue<Func<CancellationToken, Task>>();
        private SemaphoreSlim _Signal = new SemaphoreSlim(0);

        public void QueueBackgroundWorkItem(
            Func<CancellationToken, Task> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            _WorkItems.Enqueue(workItem);
            _Signal.Release();
        }

        public async Task<Func<CancellationToken, Task>> DequeueAsync(
            CancellationToken cancellationToken)
        {
            await _Signal.WaitAsync(cancellationToken);
            _WorkItems.TryDequeue(out var workItem);

            return workItem;
        }
    }
}
