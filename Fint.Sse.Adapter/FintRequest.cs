using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public ArkivActions Action { get; }
        public FintQuery Query { get; }
        public IEnumerable<object> Data { get; }

        public FintRequest(string action, string query = null, IEnumerable<object> data = null)
        {
            Action = (ArkivActions) Enum.Parse(typeof(ArkivActions), action, ignoreCase: true);

            if(query != null)
                Query = new FintQuery(query);

            Data = data;
        }
    }
}
