using System;
using System.Threading.Tasks;

namespace HelloWorld.Interfaces
{
    /// <summary>
    /// Orleans grain communication interface IHello
    /// </summary>
    public interface IHello : Orleans.IGrainWithGuidKey
    {
        Task<string> Stop(Guid? id);
    }
}
