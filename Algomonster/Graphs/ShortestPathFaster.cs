namespace ProjectDSA2.Algomonster.Graphs;

public class ShortestPathFaster
{
    public static int BFS(List<List<(int node, int weight)>> graph, int root, int target)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(root);
        int[] distance = new int[graph.Count];
        Array.Fill(distance, int.MaxValue);
        distance[root] = 0;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var (neighbor, weight) in graph[node])
            {
                if (distance[node] + weight >= distance[neighbor])
                    continue;
                queue.Enqueue(neighbor);
                distance[neighbor] = distance[node] + weight;
            }
        }

        return distance[target];
    }

    public static int ShortestPath(List<List<(int node, int weight)>> graph, int a, int b)
    {
        var result = BFS(graph, a, b);
        return result == int.MaxValue ? -1 : result;
    }

    public static void Driver()
    {
        var graph = new List<List<(int node, int weight)>>()
        {
            new() { (1, 1), (2, 1) },
            new() { (0, 1), (2, 1), (3, 1) },
            new() { (0, 1), (1, 1) },
            new() { (1, 1) },
        };
        int a = 0;
        int b = 3;
        int result = ShortestPath(graph, a, b);
        Console.WriteLine(result);
    }
}
