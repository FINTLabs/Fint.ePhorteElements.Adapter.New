using System.Collections.Generic;

namespace Fint.Sse.Adapter
{
    public class FintRequest
    {
        public string Action { get; }
        public FintQuery Query { get; }
        public IEnumerable<object> Data { get; }

        public FintRequest(string action, string query = null, IEnumerable<object> data = null)
        {
            Action = action;

            if (query != null)
                Query = new FintQuery(query);

            Data = data;
        }
    }
}
