namespace Fint.Sse.Adapter
{
    public class FintQuery
    {
        public string IdType { get; }
        public string Id { get; }
        
        public FintQuery(string query)
        {
            var queryParts = query.Split(new[] {'/'}, 2);

            IdType = queryParts[0].ToLower();

            Id = queryParts[1].ToLower();
        }
    }
}
