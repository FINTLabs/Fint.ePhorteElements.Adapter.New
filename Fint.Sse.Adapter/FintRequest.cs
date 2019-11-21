using System;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public AdapterArchiveAction Action { get; }
        public FintQuery Query { get; }

        public FintRequest(string action, string query)
        {
            Action = (AdapterArchiveAction) Enum.Parse(typeof(AdapterArchiveAction), action, ignoreCase: true);

            if(query != null)
                Query = new FintQuery(query);
        }
    }
}
