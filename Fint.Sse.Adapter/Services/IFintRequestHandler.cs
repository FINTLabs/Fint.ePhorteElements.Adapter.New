namespace Fint.Sse.Adapter.Services
{
    public interface IFintRequestHandler
    {
        FintEventData Execute(FintRequest request);
    }
}
