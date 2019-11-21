using System;
using Fint.Event.Model;
using Fint.Event.Model.Health;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fint.Sse.Adapter.Services
{
    public class EventHandlerService : IEventHandlerService
    {
        private readonly IEventStatusService _statusService;
        private readonly IHttpService _httpService;
        private readonly IFintRequestHandler _fintRequestHandler;
        private readonly ILogger<EventHandlerService> _logger;
        private readonly AppSettings _appSettings;

        public EventHandlerService(
            IEventStatusService statusService,
            IHttpService httpService,
            IFintRequestHandler fintRequestHandler,
            IOptions<AppSettings> appSettings,
            ILogger<EventHandlerService> logger)
        {
            _statusService = statusService;
            _httpService = httpService;
            _fintRequestHandler = fintRequestHandler;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public void HandleEvent(Event<object> fintEvent)
        {
            if (fintEvent.IsHealthCheck())
            {
                PostHealthCheckResponse(fintEvent);
            }
            else if (IsAccepted(fintEvent))
            {
                var fintRequest = new FintRequest(fintEvent.Action, fintEvent.Query);
                var fintEventData = _fintRequestHandler.Execute(fintRequest);

                fintEvent.Data = fintEventData;
                
                fintEvent.Status = Status.ADAPTER_RESPONSE;
                fintEvent.ResponseStatus = ResponseStatus.ACCEPTED;
                _logger.LogInformation("POST EventResponse");
                _httpService.Post(_appSettings.ResponseEndpoint, fintEvent);
            }
        }

        private bool IsAccepted(Event<object> fintEvent)
        {
            return _statusService.VerifyEvent(fintEvent).Status == Status.ADAPTER_ACCEPTED;
        }

        private void PostHealthCheckResponse(Event<object> fintEvent)
        {
            var healthCheckEvent = fintEvent;
            healthCheckEvent.Status = Status.TEMP_UPSTREAM_QUEUE;

            if (IsHealthy())
            {
                healthCheckEvent.Data.Add(new Health("adapter", HealthStatus.APPLICATION_HEALTHY));
            }
            else
            {
                healthCheckEvent.Data.Add(new Health("adapter", HealthStatus.APPLICATION_UNHEALTHY));
                healthCheckEvent.Message = "The adapter is unable to communicate with the application.";
            }

            _httpService.Post(_appSettings.ResponseEndpoint, healthCheckEvent);
        }

        private bool IsHealthy()
        {
            //Check application connectivity etc.
            return true;
        }
    }
}