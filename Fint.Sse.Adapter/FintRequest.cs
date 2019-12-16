using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Kultur.Kulturminnevern;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public object Action { get; }
        public FintQuery Query { get; }
        public IEnumerable<object> Data { get; }

        public FintRequest(string action, string query = null, IEnumerable<object> data = null)
        {
            if (Enum.TryParse(action, true, out ArkivActions arkivAction))
                Action = arkivAction;

            else if (Enum.TryParse(action, true, out KulturminnevernActions kulturminnevernAction))
                Action = kulturminnevernAction;

            if (query != null)
                Query = new FintQuery(query);

            Data = data;
        }
    }
}
