using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Felles.Kompleksedatatyper;
using Fint.Sse.Adapter.Mapping;
using FluentAssertions;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Xunit;
using Link = FINT.Model.Resource.Link;

namespace Fint.Sse.Adapter.Tests.Mapping
{
    public class EphorteElementsToFintMapperTests
    {
        [Fact]
        public void MapCaseTest()
        {
            var @case = new Case
            {
                Id = 1,
                CaseYear = 2019,
                SequenceNumber = 1234,
                Title = "SomeTitle",
                PublicTitle = "SomePublicTitle",
                CreatedDate = new DateTime(2019, 01, 01),
                CaseDate = new DateTime(2019, 01, 02),
                ClosedDate = new DateTime(2019, 01, 03),
                LoanDate = new DateTime(2019, 01, 04),
                CaseStatusId = "B",
            };

            var sakResource = new SakResource
            {
                SystemId = new Identifikator {Identifikatorverdi = "1"},
                MappeId = new Identifikator {Identifikatorverdi = "2019/1234"},
                Sakssekvensnummer = "1234",
                Tittel = "SomeTitle",
                OffentligTittel = "SomePublicTitle",
                Saksaar = "2019",
                OpprettetDato = new DateTime(2019, 01, 01),
                Saksdato = new DateTime(2019, 01, 02),
                AvsluttetDato = new DateTime(2019, 01, 03),
                UtlaantDato = new DateTime(2019, 01, 04),
            };

            sakResource.AddSaksstatus(Link.with(typeof(Saksstatus), "systemid", @case.CaseStatusId));

            EphorteElementsToFintMapper.MapCase(@case).Should().BeEquivalentTo(sakResource);
        }
        
        [Fact]
        public void MapCaseStatusesTest()
        {
            var caseStatuses = new List<CaseStatus>
            {
                new CaseStatus
                {
                    Id = "SomeId",
                    Description = "SomeDescription",
                }
            };

            EphorteElementsToFintMapper.MapCaseStatuses(caseStatuses).Should().Contain(saksStatus =>
                saksStatus.SystemId.Identifikatorverdi == "SomeId"
                && saksStatus.Kode == "SomeId"
                && saksStatus.Navn == "SomeDescription"
            );
        }
    }
}
