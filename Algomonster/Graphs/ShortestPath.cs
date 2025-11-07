namespace ProjectDSA2.Algomonster.Graphs;

public class ShortestPath
{
    public static int Shortest(List<List<int>> graph, int a, int b)
    {
        int result = 0;
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(a);
        visited.Add(a);

        while (queue.Count > 0)
        {
            int n = queue.Count();
            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                if (node == b)
                    return result;
                foreach (int neighbor in graph[node])
                {                    
                    if (visited.Contains(neighbor))
                        continue;
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
            result++;
        }

        return result;
    }

    public static void Driver()
    {
        var graph = new List<List<int>>() { 
            new() { 1, 2 },
            new() { 0, 2, 3 },
            new() { 0, 1 },
            new() { 1 },
        };
        int a = 0;
        int b = 3;
        int result = Shortest(graph, a, b);
        Console.WriteLine(result);
    }
}
