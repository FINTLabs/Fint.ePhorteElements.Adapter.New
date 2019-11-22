using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using Fint.Sse.Adapter.Services;
using Gecko.NCore.Client.ObjectModel.V3.En;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Fint.Sse.Adapter.Tests.Services
{
    public class FintRequestHandlerTests
    {
        private readonly FintRequestHandler _requestHandler;

        public FintRequestHandlerTests()
        {
            var ephorteElementsServiceMock = new Mock<IEphorteElementsService>();

            ephorteElementsServiceMock.Setup(s => s.GetCaseStatuses()).Returns(new List<CaseStatus> {new CaseStatus()});

            var loggerMock = new Mock<ILogger<FintRequestHandler>>();

            _requestHandler = new FintRequestHandler(ephorteElementsServiceMock.Object, loggerMock.Object);
        }

        [Fact]
        public void GetAllSaksStatusActionResultShouldBeObjectsOfTypeSaksstatus()
        {
            var data = _requestHandler.Execute(new FintRequest("GET_ALL_SAKSSTATUS"));

            foreach (var item in data)
            {
                Assert.IsType<Saksstatus>(item);
            }
        }
    }
}
