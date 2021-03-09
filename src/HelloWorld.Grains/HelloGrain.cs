using HelloWorld.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using Orleans.Runtime;

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

        async Task<string> IHello.Stop(int? parameter)
        {
            if(parameter != null)
            {
                await GrainFactory.GetGrain<IHelloArchive>(0).StopHelloGrain((int)parameter);
            }
            Console.WriteLine($"Staring execution of Grain method {RequestContext.ActivityId}");
            await Task.Delay(1000);
            Console.WriteLine("Execution of grain completed");
            return "";
        }
    }
}
