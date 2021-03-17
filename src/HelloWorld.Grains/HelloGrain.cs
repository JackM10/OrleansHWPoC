using HelloWorld.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using Orleans.Runtime;
using Orleans;

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

        async Task<string> IHello.Stop(Guid? id)
        {
            logger.LogError($"{this.GetPrimaryKey()} Entry Stop with params {id} in HelloGrain");
            if (id != null)
            {
                logger.LogError($"{this.GetPrimaryKey()} stopping grain with id: {id}");
                await GrainFactory.GetGrain<IHelloArchive>(Guid.Empty).StopHelloGrain((Guid)id);
            }

            logger.LogError($"{this.GetPrimaryKey()} Staring execution of Stop {RequestContext.ActivityId}, id: {id}");
            await Task.Delay(1000);
            logger.LogError($"{this.GetPrimaryKey()} Finish execution of Stop with parameter: {id}");

            return string.Empty;
        }

        public override async Task OnActivateAsync()
        {
            logger.LogError($"starting OnActivate {this.GetPrimaryKey()}");
            await base.OnActivateAsync();
            await GrainFactory.GetGrain<IHelloArchive>(Guid.NewGuid()).DoNothing();
            logger.LogError($"Finishing OnActivate {this.GetPrimaryKey()}");
        }
    }
}
