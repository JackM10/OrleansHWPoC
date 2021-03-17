using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Interfaces
{
    /// <summary>
    /// Orleans grain communication interface that will save all greetings
    /// </summary>
    public interface IHelloArchive : Orleans.IGrainWithGuidKey
    {
        Task StopHelloGrain(Guid id);

        Task DoNothing();
    }
}
