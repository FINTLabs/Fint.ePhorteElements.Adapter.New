using System.Collections.Generic;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Services
{
    public interface IEphorteElementsService
    {
        IEnumerable<CaseStatus> GetCaseStatuses();
    }
}
