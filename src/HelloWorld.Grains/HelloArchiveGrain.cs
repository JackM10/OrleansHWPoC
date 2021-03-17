using HelloWorld.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Grains
{
    public class HelloArchiveGrain : Grain, IHelloArchive
    {
        private readonly IPersistentState<GreetingArchive> _archive;
        private readonly ILogger logger;

        public HelloArchiveGrain([PersistentState("archive", "ArchiveStorage")] IPersistentState<GreetingArchive> archive, ILogger<HelloGrain> logger)
        {
            this._archive = archive;
            this.logger = logger;
        }

        public async Task StopHelloGrain(Guid id)
        {
            logger.LogError($"Start execution StopHelloGrain() in HelloGrain");
            await GrainFactory.GetGrain<IHello>(id).Stop(null);
        }

        public Task DoNothing()
        {
            return Task.CompletedTask;
        }
    }

    public class GreetingArchive
    {
        public List<string> Greetings { get; } = new List<string>();
    }
}
