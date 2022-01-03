using RTS;

Console.WriteLine("How many queries do you want to enter?");
int queryCount = Convert.ToInt32(Console.ReadLine());
List<Query> queries = new List<Query>();


for (int i = 1; i <= queryCount; i++)
{
    Console.WriteLine($"Enter query number {i}'s start");
    int start = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Enter query number {i}'s end");
    int end = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Enter query number {i}'s threshold");
    int threshold = Convert.ToInt32(Console.ReadLine());
    queries.Add(new Query(start, end, threshold));
}

queries.OrderBy(q => q.Start);

/*
 * I think i'm supposed to consider start and end values for Nodes and for the first level start=end and for higher ones start!=end
 * Then i can get all the start and end values of all queries distinct and sort them and then make the first level based on them then the -
 * second level based on the first level and so on until we get to a root which covers all the values.
 * I should keep track of each level so I can add two of the nodes as their parent's left and right child.
 *             ┌────────┐
               │        │
               │ parent │
           ┌──►│  node  │◄──┐
           │   │        │   │
           │   └────────┘   │
           │                │
        ┌──┴────┐       ┌───┴───┐
        │       │       │       │
        │ child │       │ child │
        │ node  │       │ node  │
        │       │       │       │
        └───────┘       └───────┘
 */