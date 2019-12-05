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

        public void Start()
        {
        }

        public void Scan()
        {
            if (!Directory.Exists(_cacheDirectory))
            {
                throw new DirectoryNotFoundException("file-cache does not exist");
            }

            string[] files = Directory.GetFiles(_cacheDirectory);
            foreach (var file in files)
            {
                AddFile(file);
            }
        }

        public void CleanUp()
        {
            _fileMap.Clear();
        }

        private void AddFile(string path)
        {
            _fileMap.Add(GetId(path), path);
        }

        private string GetId(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public Dokumentfil GetFile(string recNo)
        {
            return ReadFile(_fileMap[recNo]);
        }

        public void PutFile(Dokumentfil dokumentfil)
        {
            var path = SaveFile(dokumentfil);
            _fileMap.Add(GetId(path), path);
        }

        public string GetContentType(string format)
        {
            throw new System.NotImplementedException();
        }

        private Dokumentfil ReadFile(string path)
        {
            return JsonConvert.DeserializeObject<Dokumentfil>(File.ReadAllText(path));
        }

        private string SaveFile(Dokumentfil dokumentfil)
        {
            var json = JsonConvert.SerializeObject(dokumentfil);
            var path = _cacheDirectory + dokumentfil.SystemId.Identifikatorverdi + ".json";
            File.WriteAllText(path, json);

            return path;
        }

        public void OnRemoval(string removal)
        {
            throw new System.NotImplementedException();
        }

        public string Load(string recNo)
        {
            throw new System.NotImplementedException();
        }
    }
}