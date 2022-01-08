namespace RTS
{
    public class Query
    {
        public Query(double start, double end, int threshold)
        {
            Start = start;
            End = end;
            Threshold = threshold;
            Nodes = new List<Node>();
        }
        public double Start { get; set; }
        public double End { get; set; }
        public int Threshold { get; set; }
        public int Landa { get; set; }
        public int SignalCount { get; set; }
        public List<Node> Nodes { get; set; }
        public bool IsDone { get; set; } = false;

        public int RecieveSignal()
        {
            if (IsDone)
                return -1;
            SignalCount++;
            if (SignalCount < Nodes.Count)
                return Landa;
            SignalCount = 0;
            int counter = 0;

            foreach (Node node in Nodes)
                counter += node.Counter;

            if (counter >= Threshold)
            {
                IsDone = true;
                Console.WriteLine($"Query with Start: {Start} End: {End} and Threshold: {Threshold} is done");
            }

            Landa = (Threshold - counter) / (2 * Nodes.Count);
            foreach (var node in Nodes)
                node.UpdateHeap(Landa, this);

            return -1;
        }
    }
}
