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
            var friend = this._client.GetGrain<IHello>(0);
            string response1 = "no value";
            string response2 = "no value";
            await Task.Run(async () => { response1 = await friend.SayHello($"1st grain call from thread {Environment.CurrentManagedThreadId}"); });
            await Task.Run(async () => { response2 = await friend.SayHello($"2nd grain call from thread {Environment.CurrentManagedThreadId}"); });
            
            Console.WriteLine($"{response1}");
            Console.WriteLine($"{response2}");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
