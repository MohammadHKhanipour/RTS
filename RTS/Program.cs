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