using System.Collections.Generic;
using FINT.Model.Kultur.Kulturminnevern;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Services
{
    public interface IEphorteElementsService
    {
        Case GetCase(FintQuery query);
        CaseParty GetCaseParty(FintQuery query);
        IEnumerable<CaseStatus> GetCaseStatuses();
        void UpdateTilskuddFartoyCase(Case tilskuddFartoy);
    }
}
