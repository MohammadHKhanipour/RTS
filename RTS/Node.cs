namespace RTS
{
    public class Node
    {
        public Node(int counter, double start, double end, List<Query>? queries, Node? parent, Node? rightChild, Node? leftChild)
        {
            Counter = counter;
            Start = start;
            End = end;
            Parent = parent;
            RightChild = rightChild;
            LeftChild = leftChild;
        }
        public int Counter { get; set; }
        public double Start { get; set; }
        public double End { get; set; }
        public List<Sigma>? Sigmas { get; set; } = new List<Sigma>();
        public MinHeap MinHeap { get; set; }
        public Node? Parent { get; set; }
        public Node? RightChild { get; set; }
        public Node? LeftChild { get; set; }

        public void AddSigma(Query query, int landa)
        {
            Sigmas.Add(new Sigma(query, landa + Counter));
        }

        public void MakeHeap()
        {
            MinHeap = new MinHeap(Sigmas.Count * 2);
            foreach (var sigma in Sigmas)
                MinHeap.Add(sigma);
        }

        public void AddCounter()
        {
            Counter++;
            CheckRoot();
        }
        public void CheckRoot()
        {
            Sigma heapRoot;
            try
            {
                heapRoot = MinHeap.Peek();
            }
            catch (Exception ex)
            {
                return;
            }

            if (heapRoot.Value <= Counter)
            {
                MinHeap.Pop();
                CheckRoot();
                int landa = heapRoot.Query.RecieveSignal();
                if (landa >= 0)
                    MinHeap.Add(new Sigma(heapRoot.Query, landa + Counter));
            }
        }
        public void UpdateHeap(int landa, Query query)
        {
            MinHeap.Add(new Sigma(query, landa + Counter));
        }
    }
}
