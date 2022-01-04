namespace RTS
{
    public class Node
    {
        public Node(int counter, float start, float end, List<Query>? queries, Node? parent, Node? rightChild, Node? leftChild)
        {
            Counter = counter;
            Start = start;
            End = end;
            Queries = queries;
            Parent = parent;
            RightChild = rightChild;
            LeftChild = leftChild;
        }
        public int Counter { get; set; }
        public float Start { get; set; }
        public float End { get; set; }
        public List<Query>? Queries { get; set; }
        public Node? Parent { get; set; }
        public Node? RightChild { get; set; }
        public Node? LeftChild { get; set; }
    }
}
