using System.Threading.Tasks;
using GulkortetNETFramework.Responses;

namespace GulkortetNETFramework.Services.Interfaces
{

    // Ett interface för att kunna göra DI sami IOC
    public interface IIncomingDataValidator
    {
        Task<ValidatedDataResponse> Validate(string incomingMessage);
    }
}
