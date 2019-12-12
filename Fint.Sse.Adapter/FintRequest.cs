using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Arkiv;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public string Action{ get; }
        public FintQuery Query { get; }
        public IEnumerable<object> Data { get; }

        public FintRequest(string action, string query = null, IEnumerable<object> data = null)
        {
            //Action = (Enum) Enum.Parse(typeof(Enum), action, ignoreCase: true);
            Action = action;

            if(query != null)
                Query = new FintQuery(query);

            Data = data;
        }
    }
}
