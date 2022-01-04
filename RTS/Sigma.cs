namespace RTS
{
    public class Sigma
    {
        public Sigma(Query query, int value)
        {
            Query = query;
            Value = value;
        }

        public Query Query { get; set; }
        public int Value { get; set; }
    }
}
