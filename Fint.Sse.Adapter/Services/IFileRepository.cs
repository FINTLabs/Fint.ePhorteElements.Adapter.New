using FINT.Model.Administrasjon.Arkiv;

namespace Fint.Sse.Adapter.Services
{
    public interface IFileRepository
    {
        void Scan();
        void Start();
        void CleanUp();
        //void AddFile(string path);
        //string GetId(string path);
        Dokumentfil GetFile(string recNo);
        void PutFile(Dokumentfil resource);
        string GetContentType(string format);
        //Dokumentfil ReadFile(string path);
        //string SaveFile(Dokumentfil dokumentfilResource);
        void OnRemoval(string removal);
        string Load(string recNo);
    }
}
