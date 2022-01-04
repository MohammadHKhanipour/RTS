namespace RTS
{
    public class Query
    {
        public Query(float start, float end, int threshold)
        {
            Start = start;
            End = end;
            Threshold = threshold;
        }
        public float Start { get; set; }
        public float End { get; set; }
        public int Threshold { get; set; }
    }
}
