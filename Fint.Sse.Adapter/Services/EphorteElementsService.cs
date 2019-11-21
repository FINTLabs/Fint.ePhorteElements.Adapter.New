using Fint.Sse.Adapter.Services.NCore;
using Gecko.NCore.Client;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Services
{
    public class EphorteElementsService : IEphorteElementsService
    {
        private static IEphorteContext EphorteContext { get; set; }

        public EphorteElementsService(NCoreFactory nCoreFactory)
        {
            EphorteContext = nCoreFactory.Create();
        }
    }
}
