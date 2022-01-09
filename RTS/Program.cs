using RTS;

Console.WriteLine("How many queries do you want to enter?");
int queryCount = Convert.ToInt32(Console.ReadLine());
List<Query> queries = new List<Query>();


for (int i = 1; i <= queryCount; i++)
{
    Console.WriteLine($"Enter query number {i}'s start");
    double start = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Enter query number {i}'s end");
    double end = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Enter query number {i}'s threshold");
    int threshold = Convert.ToInt32(Console.ReadLine());
    queries.Add(new Query(start, end, threshold));
}

List<double> values = new List<double>();
foreach (var item in queries)
{
    values.Add(item.Start);
    values.Add(item.End);
}

var treeRoot = GenerateTree(values.Distinct().OrderBy(x => x).ToList());

/*
                                                  ┌──────┐
                                                  │ root │
                                ┌─────────────────┤ node ├───────────────────┐
                                │                 └──────┘                   │
                                │                                         │
                                │                                         │
                          ┌─────▼──────┐                           ┌──────▼──────┐
                          │ left child │                           │ right child │
                      ┌───┤  /parent   ├───┐                   ┌───┤   /parent   ├───┐
                      │   └────────────┘   │                   │   └─────────────┘   │
                      │                    │                   │                     │
                      │                    │                   │                     │
                ┌─────▼──────┐      ┌──────▼──────┐      ┌─────▼──────┐       ┌──────▼──────┐
                │ left child │      │ right child │      │ left child │       │ right child │
                │  /parent   │      │   /parent   │      │  /parent   │       │   /parent   │
                └────────────┘      └─────────────┘      └────────────┘       └─────────────┘

                                                  ...
 */

AddSigmas(treeRoot, queries);
MakeNodeHeap(treeRoot);

Console.WriteLine("Enter values: ");
while (true)
{
    double value = Convert.ToDouble(Console.ReadLine());
    AddCounter(treeRoot, value);
}

Node GenerateTree(List<double> input)
{
    int inputCount = input.Count;
    List<Node> nodes = new List<Node>();
    int nodeCount = (2 * inputCount) - 1;

    Queue<Node> nodesQueue = new Queue<Node>();
    for (int i = 0; i < inputCount - 1; i++)
    {
        nodesQueue.Enqueue(new Node(0, input[i], input[i + 1], null, null, null, null));
    }
    nodesQueue.Enqueue(new Node(0, input[inputCount - 1], -1, null, null, null, null));

    while (nodesQueue.Count > 1)
    {
        Node leftNode = nodesQueue.Dequeue();
        Node rightNode = nodesQueue.Dequeue();
        Node parentNode = new Node(0, leftNode.Start, rightNode.End, null, null, rightNode, leftNode);
        leftNode.Parent = parentNode;
        rightNode.Parent = parentNode;
        nodesQueue.Enqueue(parentNode);
    }

    Node root = nodesQueue.Dequeue();

    return root;
}

List<Node> FindNodes(Query query, Node root)
{
    List<Node> nodes = new List<Node>();
    Stack<Node> stack = new Stack<Node>();

    stack.Push(root);

    while (stack.Count > 0)
    {
        Node node = stack.Pop();
        if (node == null)
            continue;
        if (node.Start >= query.Start && node.End <= query.End && node.End != -1)
            nodes.Add(node);
        else if (node.Start > query.End || (node.End < query.Start && node.End != -1))
            continue;
        stack.Push(node.RightChild);
        stack.Push(node.LeftChild);
    }

    return nodes;
}

void AddSigmas(Node root, List<Query> queries)
{
    foreach (var query in queries)
    {
        List<Node> nodes = FindNodes(query, root);
        query.Nodes = nodes;
        int landa = query.Threshold / (2 * nodes.Count);
        query.Landa = landa;
        foreach (var node in nodes)
            node.AddSigma(query, landa);
    }
}

void MakeNodeHeap(Node root)
{
    if (root == null)
        return;
    root.MakeHeap();
    MakeNodeHeap(root.LeftChild);
    MakeNodeHeap(root.RightChild);
}

void AddCounter(Node node, double value)
{
    if (node == null)
        return;
    if (node.Start > value || (node.End <= value && node.End != -1))
        return;
    node.AddCounter();
    AddCounter(node.LeftChild, value);
    AddCounter(node.RightChild, value);
}