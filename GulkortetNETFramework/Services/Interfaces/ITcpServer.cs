using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable UnusedMemberInSuper.Global

namespace GulkortetNETFramework.Services.Interfaces
{
    // Ett interface för att kunna göra DI sami IOC
    public interface ITcpServer
    {
        void ReadStream();
        Task WriteToStream(string message);
        Task StartServer(ListView view);
    }
}