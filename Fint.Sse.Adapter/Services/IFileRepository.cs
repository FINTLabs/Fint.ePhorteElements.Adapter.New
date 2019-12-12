using FINT.Model.Administrasjon.Arkiv;

namespace Fint.Sse.Adapter.Services
{
    public interface IFileRepository
    {
        void Scan();
        void Start();
        void CleanUp();
        Dokumentfil GetFile(string recNo);
        void PutFile(Dokumentfil dokumentfil);
        string GetContentType(string format);
        void OnRemoval(string removal);
        string Load(string recNo);
    }
}
