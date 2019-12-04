using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Felles.Kompleksedatatyper;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Link = FINT.Model.Resource.Link;

namespace Fint.Sse.Adapter.Mapping
{
    public static class EphorteElementsToFintMapper
    {
        public static SakResource MapCase(Case @case)
        {
            var sak = new SakResource
            {
                SystemId = new Identifikator {Identifikatorverdi = @case.Id.ToString()},
                MappeId = new Identifikator {Identifikatorverdi = $"{@case.CaseYear}/{@case.SequenceNumber}"},
                Sakssekvensnummer = @case.SequenceNumber.ToString(),
                Tittel = @case.Title,
                OffentligTittel = @case.PublicTitle,
                Saksaar = @case.CaseYear.ToString(),
                OpprettetDato = SetUtcTimeZone(@case.CreatedDate),
                Saksdato = SetUtcTimeZone(@case.CaseDate),
                AvsluttetDato = SetUtcTimeZone(@case.ClosedDate),
                UtlaantDato = SetUtcTimeZone(@case.LoanDate),
            };

            sak.AddSaksstatus(Link.with(typeof(Saksstatus), "systemid", @case.CaseStatusId));

            return sak;
        }

        public static PartResource MapCaseParty(CaseParty caseParty)
        {
            var part = new PartResource
            {
                PartId = new Identifikator {Identifikatorverdi = caseParty.Id.ToString()},
                PartNavn = caseParty.Name,
                Kontaktperson = caseParty.Attention,
                Kontaktinformasjon = new Kontaktinformasjon
                {
                    Epostadresse = caseParty.Email,
                    Telefonnummer = caseParty.Telephone,
                },
                Adresse = new AdresseResource
                {
                    Adresselinje = new List<string> {caseParty.PostalAddress},
                    Postnummer = caseParty.PostalCode,
                    Poststed = caseParty.City,
                },
            };

            part.Links.Add("sak", new List<Link> {Link.with(typeof(Sak), "systemid", caseParty.CaseId.ToString())});

            return part;
        }

        public static IEnumerable<Saksstatus> MapCaseStatuses(IEnumerable<CaseStatus> caseStatuses)
        {
            var saksstatuses = new List<Saksstatus>();

            foreach (var caseStatus in caseStatuses)
            {
                saksstatuses.Add(new Saksstatus
                {
                    SystemId = new Identifikator
                    {
                        Identifikatorverdi = caseStatus.Id
                    },
                    Kode = caseStatus.Id,
                    Navn = caseStatus.Description
                });
            }

            return saksstatuses;
        }

        private static DateTime SetUtcTimeZone(DateTime? dateTime)
        {
            return DateTime.SpecifyKind(dateTime.GetValueOrDefault(), DateTimeKind.Utc);
        }
    }
}
