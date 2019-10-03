using Fint.Event.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fint.Sse.Adapter.Services
{
    public class EventStatusService : IEventStatusService
    {
        private readonly IHttpService _httpService;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public EventStatusService(ILogger<HttpService> logger, IHttpService httpService,
            IOptions<AppSettings> appSettings)
        {
            _httpService = httpService;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public Event<object> VerifyEvent(Event<object> fintEvent)
        {
            if (ActionUtils.IsValidStatusAction(fintEvent.Action))
            {
                fintEvent.Status = Status.ADAPTER_ACCEPTED;
            }
            else
            {
                fintEvent.Status = Status.ADAPTER_REJECTED;
            }
            
            PostStatus(fintEvent);

            return fintEvent;
        }

        private void PostStatus(Event<object> evt)
        {
            _logger.LogInformation("POST Status");
            _httpService.Post(_appSettings.StatusEndpoint, evt);
        }
    }
}