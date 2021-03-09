using System;
using System.Threading;
using System.Threading.Tasks;
using HelloWorld.Interfaces;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Runtime;

namespace OrleansClient
{
    public class HelloWorldClientHostedService : IHostedService
    {
        private readonly IClusterClient _client;

        public HelloWorldClientHostedService(IClusterClient client)
        {
            this._client = client;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            RequestContext.ActivityId = Guid.NewGuid();
            var task1 = Task.Run(() => { return _client.GetGrain<IHello>(0).Stop(null); });
            var task2 = Task.Run(() => { return _client.GetGrain<IHello>(1).Stop(0); });
            await Task.WhenAll(task1, task2);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
