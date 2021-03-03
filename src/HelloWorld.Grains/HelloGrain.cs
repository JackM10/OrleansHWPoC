using HelloWorld.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace HelloWorld.Grains
{
    /// <summary>
    /// Orleans grain implementation class HelloGrain.
    /// </summary>
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger logger;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
        }  

        Task<string> IHello.SayHello(string greeting)
        {
            return Task.FromResult($"Message from Client: {greeting}, Response from Grain, threadId - {Environment.CurrentManagedThreadId}");
        }
    }
}
