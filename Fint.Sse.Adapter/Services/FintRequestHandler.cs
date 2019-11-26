using System;
using Fint.Sse.Adapter.Mapping;
using Microsoft.Extensions.Logging;

namespace Fint.Sse.Adapter.Services
{
    public class FintRequestHandler : IFintRequestHandler
    {
        private readonly IEphorteElementsService _ePhorteElementsService;
        private readonly ILogger<FintRequestHandler> _logger;

        public FintRequestHandler(IEphorteElementsService ePhorteElementsService, ILogger<FintRequestHandler> logger)
        {
            _ePhorteElementsService = ePhorteElementsService;
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
                    return OnGetAllSaksstatusAction();

                case AdapterArchiveAction.GET_ALL_PARTROLLE:
                    return OnGetAllPartRolleAction();

                case AdapterArchiveAction.GET_ALL_DOKUMENTSTATUS:
                    return OnGetAllDokumentstatusAction();

                case AdapterArchiveAction.GET_ALL_DOKUMENTTYPE:
                    return OnGetAllDokumenttypeAction();

                case AdapterArchiveAction.GET_ALL_JOURNALSTATUS:
                    return OnGetAllJournalStatusAction();

                case AdapterArchiveAction.GET_ALL_JOURNALPOSTTYPE:
                    return OnGetAllJournalpostTypeAction();

                case AdapterArchiveAction.GET_ALL_KORRESPONDANSEPARTTYPE:
                    return OnGetAllKorrespondansepartTypeAction();

                case AdapterArchiveAction.GET_ALL_MERKNADSTYPE:
                    return OnGetAllMerknadstypeAction();

                case AdapterArchiveAction.GET_ALL_SKJERMINGSHJEMMEL:
                    return OnGetAllSkjermingshjemmelAction();

                case AdapterArchiveAction.GET_ALL_TILGANGSRESTRIKSJON:
                    return OnGetAllTilgangsrestriksjonAction();

                case AdapterArchiveAction.GET_ALL_TILKNYTTETREGISTRERINGSOM:
                    return OnGetAllTilknyttetRegistreringSomAction();

                case AdapterArchiveAction.GET_ALL_VARIANTFORMAT:
                    return OnGetAllVariantformatAction();

                default:
                    var message = $"Unhandled action: {request.Action}";
                    _logger.LogError(message);
                    throw new Exception(message);
            }
        }

        // User read actions

        private FintEventData OnGetSakAction(FintQuery query)
        {
            var @case = _ePhorteElementsService.GetCase(query);

            var sak = EphorteElementsToFintMapper.MapCase(@case);

            return new FintEventData {sak};
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

        private FintEventData OnGetAllSaksstatusAction()
        {
            var caseStatuses = _ePhorteElementsService.GetCaseStatuses();

            var saksStatuses = EphorteElementsToFintMapper.MapCaseStatuses(caseStatuses);

            return new FintEventData {saksStatuses};
        }

        private FintEventData OnGetAllPartRolleAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllDokumentstatusAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllDokumenttypeAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllJournalStatusAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllJournalpostTypeAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllKorrespondansepartTypeAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllMerknadstypeAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllSkjermingshjemmelAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllTilgangsrestriksjonAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllTilknyttetRegistreringSomAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }

        private FintEventData OnGetAllVariantformatAction()
        {
            // TODO: Implement

            return new FintEventData { };
        }
    }
}
