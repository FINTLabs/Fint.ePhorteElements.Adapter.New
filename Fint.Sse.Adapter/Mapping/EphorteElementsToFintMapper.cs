using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Felles.Kompleksedatatyper;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Mapping
{
    public static class EphorteElementsToFintMapper
    {
        public static List<Saksstatus> MapCaseStatuses(IEnumerable<CaseStatus> caseStatuses)
        {
            var mapCaseStatuses = new List<Saksstatus>();

            foreach (var caseStatus in caseStatuses)
            {
                mapCaseStatuses.Add(new Saksstatus
                {
                    SystemId = new Identifikator
                    {
                        Identifikatorverdi = caseStatus.Id
                    },
                    Kode = caseStatus.Id,
                    Navn = caseStatus.Description
                });
            }

            return mapCaseStatuses;
        }
    }
}
