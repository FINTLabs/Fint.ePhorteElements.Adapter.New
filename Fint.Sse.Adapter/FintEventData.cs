using System.Collections.Generic;

namespace Fint.Sse.Adapter
{
    public class FintEventData : List<object>
    {
        public void Add(IEnumerable<object> data)
        {
            AddRange(data);
        }
    }
}
