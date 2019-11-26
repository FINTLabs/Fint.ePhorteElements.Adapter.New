using System.Collections.Generic;
using System.Linq;
using FINT.Model.Administrasjon.Arkiv;
using Fint.Sse.Adapter.Services;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using FluentAssertions;

namespace Fint.Sse.Adapter.Tests.Services
{
    public class FintRequestHandlerTests
    {
        private readonly FintRequestHandler _requestHandler;

        public FintRequestHandlerTests()
        {
            var ephorteElementsServiceMock = new Mock<IEphorteElementsService>();

            ephorteElementsServiceMock.Setup(s => s.GetCase(It.IsAny<FintQuery>())).Returns(new Case());
            ephorteElementsServiceMock.Setup(s => s.GetCaseStatuses()).Returns(new List<CaseStatus> {new CaseStatus()});

            var loggerMock = new Mock<ILogger<FintRequestHandler>>();

            _requestHandler = new FintRequestHandler(ephorteElementsServiceMock.Object, loggerMock.Object);
        }

        [Fact]
        public void GetSakActionResultShouldBeAnObjectOfTypeSakResource()
        {
            var data = _requestHandler.Execute(new FintRequest("GET_SAK", "someIdType/someId"));

            data.First().Should().BeOfType<SakResource>();
        }

        [Fact]
        public void GetAllSaksStatusActionResultShouldBeObjectsOfTypeSaksstatus()
        {
            var data = _requestHandler.Execute(new FintRequest("GET_ALL_SAKSSTATUS"));

            foreach (var item in data)
            {
                item.Should().BeOfType<Saksstatus>();
            }
        }
    }
}
