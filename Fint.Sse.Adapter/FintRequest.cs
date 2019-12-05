using System;
using System.Collections.Generic;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public AdapterArchiveAction Action { get; }
        public FintQuery Query { get; }
        public IEnumerable<object> Data { get; }

        public FintRequest(string action, string query = null, IEnumerable<object> data = null)
        {
            Action = (AdapterArchiveAction) Enum.Parse(typeof(AdapterArchiveAction), action, ignoreCase: true);

            if(query != null)
                Query = new FintQuery(query);

            Data = data;
        }
    }
}
