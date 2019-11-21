using System;
using Microsoft.Extensions.Logging;

namespace Fint.Sse.Adapter.Services
{
    public class FintRequestHandler : IFintRequestHandler
    {
        private readonly ILogger<EventHandlerService> _logger;

        public FintRequestHandler(ILogger<EventHandlerService> logger)
        {
            _logger = logger;
        }

        public FintEventData Execute(FintRequest request)
        {
            switch (request.Action)
            {
                // User read actions

                case AdapterArchiveAction.GET_SAK:
                    return OnGetSakAction(request.Query);

                case AdapterArchiveAction.GET_PART:
                    return OnGetPartAction(request.Query);

                case AdapterArchiveAction.GET_DOKUMENTFIL:
                    return OnGetDokumentfilAction(request.Query);

                case AdapterArchiveAction.GET_KORRESPONDANSEPART:
                    return OnGetKorrespondansepartAction(request.Query);

                // User write actions

                case AdapterArchiveAction.UPDATE_DOKUMENTFIL:
                    return OnUpdateDokumentfilAction(request.Query);

                case AdapterArchiveAction.UPDATE_KORRESPONDANSEPART:
                    return OnUpdateKorrespondansepartAction(request.Query);

                // FINT cache update read actions

                case AdapterArchiveAction.GET_ALL_SAKSSTATUS:
                    return OnGetAllSaksstatusAction(request.Query);

                case AdapterArchiveAction.GET_ALL_PARTROLLE:
                    return OnGetAllPartRolleAction(request.Query);

                case AdapterArchiveAction.GET_ALL_DOKUMENTSTATUS:
                    return OnGetAllDokumentstatusAction(request.Query);

                case AdapterArchiveAction.GET_ALL_DOKUMENTTYPE:
                    return OnGetAllDokumenttypeAction(request.Query);

                case AdapterArchiveAction.GET_ALL_JOURNALSTATUS:
                    return OnGetAllJournalStatusAction(request.Query);

                case AdapterArchiveAction.GET_ALL_JOURNALPOSTTYPE:
                    return OnGetAllJournalpostTypeAction(request.Query);

                case AdapterArchiveAction.GET_ALL_KORRESPONDANSEPARTTYPE:
                    return OnGetAllKorrespondansepartTypeAction(request.Query);

                case AdapterArchiveAction.GET_ALL_MERKNADSTYPE:
                    return OnGetAllMerknadstypeAction(request.Query);

                case AdapterArchiveAction.GET_ALL_SKJERMINGSHJEMMEL:
                    return OnGetAllSkjermingshjemmelAction(request.Query);

                case AdapterArchiveAction.GET_ALL_TILGANGSRESTRIKSJON:
                    return OnGetAllTilgangsrestriksjonAction(request.Query);

                case AdapterArchiveAction.GET_ALL_TILKNYTTETREGISTRERINGSOM:
                    return OnGetAllTilknyttetRegistreringSomAction(request.Query);

                case AdapterArchiveAction.GET_ALL_VARIANTFORMAT:
                    return OnGetAllVariantformatAction(request.Query);

                default:
                    var message = $"Unhandled action: {request.Action}";
                    _logger.LogError(message);
                    throw new Exception(message);
            }
        }

        // User read actions

        private FintEventData OnGetSakAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetPartAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetDokumentfilAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetKorrespondansepartAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        // User write actions

        private FintEventData OnUpdateDokumentfilAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnUpdateKorrespondansepartAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        // FINT cache update read actions

        private FintEventData OnGetAllSaksstatusAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllPartRolleAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllDokumentstatusAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllDokumenttypeAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllJournalStatusAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllJournalpostTypeAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllKorrespondansepartTypeAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllMerknadstypeAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllSkjermingshjemmelAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllTilgangsrestriksjonAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllTilknyttetRegistreringSomAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllVariantformatAction(FintQuery query)
        {
            // TODO: Implement

            return new FintEventData { };
        }
    }
}
