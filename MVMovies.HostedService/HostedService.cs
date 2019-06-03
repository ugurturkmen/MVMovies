using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVMovies.HostedService
{
    public abstract class HostedService : IHostedService, IDisposable
    {
        private Task currentTask;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected abstract Task executeAsync(CancellationToken cToken);
        public void Dispose()
        {
            cancellationTokenSource.Cancel();
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            currentTask = executeAsync(cancellationTokenSource.Token);

            if (currentTask.IsCompleted)
                return currentTask;

            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (currentTask == null)
                return;

            try
            {
                cancellationTokenSource.Cancel();
            }
            finally
            {
                await Task.WhenAny(currentTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }
    }
}
