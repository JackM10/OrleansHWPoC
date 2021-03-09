using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Interfaces
{
    /// <summary>
    /// Orleans grain communication interface that will save all greetings
    /// </summary>
    public interface IHelloArchive : Orleans.IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
        Task StopHelloGrain(int id);

        Task<IEnumerable<string>> GetGreetings();
    }
}
