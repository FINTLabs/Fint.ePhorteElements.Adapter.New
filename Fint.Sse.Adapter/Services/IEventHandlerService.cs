using Fint.Event.Model;

namespace Fint.Sse.Adapter.Services
{
    public interface IEventHandlerService
    {
        void HandleEvent(SseEndpoint endpoint, Event<object> fintEvent);
    }
}