using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;

namespace Fint.Sse.Adapter
{
    public class AdapterActions
    {
        public static List<ArkivActions> GetArchiveActions { get; private set; }

        public AdapterActions()
        {
            GetArchiveActions = new List<ArkivActions>
            {
                ArkivActions.GET_ALL_DOKUMENTSTATUS,
                ArkivActions.GET_ALL_DOKUMENTTYPE,
                ArkivActions.GET_DOKUMENTFIL,
                ArkivActions.UPDATE_DOKUMENTFIL,
                ArkivActions.GET_ALL_JOURNALSTATUS,
                ArkivActions.GET_ALL_JOURNALPOSTTYPE,
                ArkivActions.GET_KORRESPONDANSEPART,
                ArkivActions.UPDATE_KORRESPONDANSEPART,
                ArkivActions.GET_ALL_KORRESPONDANSEPARTTYPE,
                ArkivActions.GET_ALL_MERKNADSTYPE,
                ArkivActions.GET_PART,
                ArkivActions.GET_ALL_PARTROLLE,
                ArkivActions.GET_SAK,
                ArkivActions.GET_ALL_SAKSSTATUS,
                ArkivActions.GET_ALL_SKJERMINGSHJEMMEL,
                ArkivActions.GET_ALL_TILGANGSRESTRIKSJON,
                ArkivActions.GET_ALL_TILKNYTTETREGISTRERINGSOM,
                ArkivActions.GET_ALL_VARIANTFORMAT,
            };
        }
    }
}
