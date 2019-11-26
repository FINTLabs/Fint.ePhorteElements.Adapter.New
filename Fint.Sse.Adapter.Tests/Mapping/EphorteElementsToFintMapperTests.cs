using System.Collections.Generic;
using Fint.Sse.Adapter.Mapping;
using FluentAssertions;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Xunit;

namespace Fint.Sse.Adapter.Tests.Mapping
{
    public class EphorteElementsToFintMapperTests
    {
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
