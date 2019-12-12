using System;
using System.Collections.Generic;
using System.IO;
using FINT.Model.Administrasjon.Arkiv;
using Newtonsoft.Json;

namespace Fint.Sse.Adapter.Services
{
    public class FileRepository : IFileRepository
    {
        private readonly Dictionary<string, string> _fileMap = new Dictionary<string, string>();
        private readonly string _cacheDirectory = AppDomain.CurrentDomain.BaseDirectory + "file-cache/";

        public void Scan()
        {
            if (!Directory.Exists(_cacheDirectory))
                throw new DirectoryNotFoundException("file-cache does not exist");

            var files = Directory.GetFiles(_cacheDirectory);
            
            foreach (var file in files)
                AddFile(file);
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void CleanUp()
        {
            _fileMap.Clear();
        }

        private void AddFile(string filePath)
        {
            _fileMap.Add(GetId(filePath), filePath);
        }

        private static string GetId(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public Dokumentfil GetFile(string fileId)
        {
            return ReadFile(_fileMap[fileId]);
        }

        public void PutFile(Dokumentfil dokumentfil)
        {
            var filePath = SaveFile(dokumentfil);
            
            _fileMap.Add(GetId(filePath), filePath);
        }

        public string GetContentType(string format)
        {
            throw new NotImplementedException();
        }

        public void OnRemoval(string removal)
        {
            throw new NotImplementedException();
        }

        public string Load(string recNo)
        {
            throw new NotImplementedException();
        }

        private static Dokumentfil ReadFile(string filePath)
        {
            return JsonConvert.DeserializeObject<Dokumentfil>(File.ReadAllText(filePath));
        }

        private string SaveFile(Dokumentfil dokumentfil)
        {
            if (!Directory.Exists(_cacheDirectory))
                throw new DirectoryNotFoundException("file-cache does not exist");

            var fileJson = JsonConvert.SerializeObject(dokumentfil);
            
            var filePath = _cacheDirectory + dokumentfil.SystemId.Identifikatorverdi + ".json";
            
            File.WriteAllText(filePath, fileJson);

            return filePath;
        }
    }
}
