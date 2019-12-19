using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using Gecko.NCore.Client.ObjectModel.V3.En;

namespace Fint.Sse.Adapter.Mapping
{
    public static class FintToEphorteElementsMapper
    {
        public static RegistryEntry MapJournalPost(JournalpostResource journalpost)
        {
            var registryEntry = new RegistryEntry {Title = journalpost.Tittel};

            foreach (var dokumentBeskrivelse in journalpost.Dokumentbeskrivelse)
            {
                var documentDescription = new DocumentDescription
                {
                    Id = 0,
                    CreatedDate = null,
                    //RegistryEntryDocuments -> Add...
                    SourceDatabase = null,
                    ExtensionData = null,
                    AccessCodeId = null,
                    LastUpdated = null,
                    AccessCode = null,
                    CurrentVersion = null,
                    IsPublished = null,
                    CreatedByUserNameId = 0,
                    DocumentStatus = null,
                    AccessGroup = null,
                    AccessGroupId = null,
                    DisposalCode = null,
                    DisposalCodeId = null,
                    Pursuant = null,
                    PreservationTime = null,
                    PreparedById = null,
                    PreparedBy = null,
                    Localization = null,
                    IsPhysical = null,
                    DowngradingDate = null,
                    DowngradingCodeId = null,
                    DowngradingCode = null,
                    DocumentTitle = null,
                    DocumentStatusId = null,
                    DocumentCategoryId = null,
                    DocumentCategory = null,
                    DisposedDate = null,
                    DisposedBy = null,
                    DisposalDate = null,
                };

                foreach (var dokumentObjekt in dokumentBeskrivelse.Dokumentobjekt)
                {
                    documentDescription.DocumentObjects.Add(new DocumentObject
                    {
                        CreatedDate = null,
                        VariantFormat = null,
                        FileFormat = new FileFormat
                        {
                            Id = null,
                            Description = null,
                            SourceDatabase = null,
                            ExtensionData = null,
                            FileExtension = null,
                            IsArchivalFormat = false,
                        },
                        DocumentDescription = null,
                        ContentType = null,
                        SourceDatabase = null,
                        ExtensionData = null,
                        AccessCode = null,
                        AccessCodeId = null,
                        DocumentDescriptionId = 0,
                        FilePath = null,
                        UpdatedByUserNameId = null,
                        CheckedOutByUserId = null,
                        CheckedOutToFilePath = null,
                        ReservedByUserNameId = null,
                        IsCompound = null,
                        LastUpdated = null,
                        StorageUnit = null,
                        KeepUntilDate = null,
                        ArchiveRemark = null,
                        StorageUnitId = null,
                        IsPublished = null,
                        IsConverting = null,
                        ReservedByUserName = null,
                        LocalFilePath = null,
                        CreatedByUserName = null,
                        CurrentVersion = null,
                        Checksum = null,
                        UpdatedByUserName = null,
                        VariantFormatId = null,
                        ConversionRetryCount = null,
                        FileSize = int.Parse(dokumentObjekt.Filstorrelse),
                        CreatedByUserNameId = null,
                        CheckSumAlgorithm = null,
                        CheckedOutByUser = null,
                        FileformatId = null,
                        VersionNumber = 0,
                    });
                }

                registryEntry.RegistryEntryDocuments.Add(new RegistryEntryDocument
                {
                    DocumentDescription = documentDescription,
                    CreatedDate = null,
                    SourceDatabase = null,
                    ExtensionData = null,
                    RegistryEntry = null,
                    DocumentDescriptionId = 0,
                    AttachedByUserName = null,
                    AttachedByUserNameId = null,
                    ConnectedDate = null,
                    UpdatedDate = null,
                    SortOrder = 0,
                    RegistryEntryId = 0,
                    DocumentLinkTypeId = null,
                    DocumentLinkType = null,
                });
            }

            return registryEntry;
        }
    }
}
