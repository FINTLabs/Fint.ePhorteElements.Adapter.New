using System;
using System.Collections.Generic;
using System.Linq;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Kultur.Kulturminnevern;
using Fint.Sse.Adapter.Mapping;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fint.Sse.Adapter.Services
{
    public class FintRequestHandler : IFintRequestHandler
    {
        private readonly IEphorteElementsService _ePhorteElementsService;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger<FintRequestHandler> _logger;

        public FintRequestHandler(IEphorteElementsService ePhorteElementsService, IFileRepository fileRepository,
            ILogger<FintRequestHandler> logger)
        {
            _ePhorteElementsService = ePhorteElementsService;
            _fileRepository = fileRepository;
            _logger = logger;
        }

        public FintEventData Execute(FintRequest request)
        {
            switch (request.Action)
            {
                // User read actions

                case ArkivActions.GET_SAK:
                    return OnGetSakAction(request.Query);

                case ArkivActions.GET_PART:
                    return OnGetPartAction(request.Query);

                case ArkivActions.GET_DOKUMENTFIL:
                    return OnGetDokumentfilAction(request.Query);

                case ArkivActions.GET_KORRESPONDANSEPART:
                    return OnGetKorrespondansepartAction(request.Query);

                // User write actions

                case ArkivActions.UPDATE_DOKUMENTFIL:
                    OnUpdateDokumentfilAction(request.Data);
                    return null;

                case ArkivActions.UPDATE_KORRESPONDANSEPART:
                    return OnUpdateKorrespondansepartAction(request.Query);

                case KulturminnevernActions.UPDATE_TILSKUDDFARTOY:
                    return OnUpdateTilskuddFartoy(request.Data);

                // FINT cache update read actions

                case ArkivActions.GET_ALL_SAKSSTATUS:
                    return OnGetAllSaksstatusAction();

                case ArkivActions.GET_ALL_PARTROLLE:
                    return OnGetAllPartRolleAction();

                case ArkivActions.GET_ALL_DOKUMENTSTATUS:
                    return OnGetAllDokumentstatusAction();

                case ArkivActions.GET_ALL_DOKUMENTTYPE:
                    return OnGetAllDokumenttypeAction();

                case ArkivActions.GET_ALL_JOURNALSTATUS:
                    return OnGetAllJournalStatusAction();

                case ArkivActions.GET_ALL_JOURNALPOSTTYPE:
                    return OnGetAllJournalpostTypeAction();

                case ArkivActions.GET_ALL_KORRESPONDANSEPARTTYPE:
                    return OnGetAllKorrespondansepartTypeAction();

                case ArkivActions.GET_ALL_MERKNADSTYPE:
                    return OnGetAllMerknadstypeAction();

                case ArkivActions.GET_ALL_SKJERMINGSHJEMMEL:
                    return OnGetAllSkjermingshjemmelAction();

                case ArkivActions.GET_ALL_TILGANGSRESTRIKSJON:
                    return OnGetAllTilgangsrestriksjonAction();

                case ArkivActions.GET_ALL_TILKNYTTETREGISTRERINGSOM:
                    return OnGetAllTilknyttetRegistreringSomAction();

                case ArkivActions.GET_ALL_VARIANTFORMAT:
                    return OnGetAllVariantformatAction();
            }
            var message = $"Unhandled action: {request.Action}";
            _logger.LogError(message);
            throw new Exception(message);
        }

        private FintEventData OnUpdateTilskuddFartoy(IEnumerable<object> requestData)
        {
            throw new NotImplementedException();
        }

        // User read actions

        private FintEventData OnGetSakAction(FintQuery query)
        {
            var @case = _ePhorteElementsService.GetCase(query);

            if (@case == null) return null;

            var sak = EphorteElementsToFintMapper.MapCase(@case);

            return new FintEventData {sak};
        }

        private FintEventData OnGetPartAction(FintQuery query)
        {
            var caseParty = _ePhorteElementsService.GetCaseParty(query);

            if (caseParty == null) return null;

            var part = EphorteElementsToFintMapper.MapCaseParty(caseParty);

            return new FintEventData {part};
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

        private void OnUpdateDokumentfilAction(IEnumerable<object> data)
        {
            var dokumentfil = JsonConvert.DeserializeObject<Dokumentfil>(data.FirstOrDefault()?.ToString());

            _fileRepository.PutFile(dokumentfil);
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

            if (caseStatuses == null) return null;

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