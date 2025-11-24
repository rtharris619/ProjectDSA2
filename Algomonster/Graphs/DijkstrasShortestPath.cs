namespace ProjectDSA2.Algomonster.Graphs;

public class DijkstrasShortestPath
{
    public static int BFS(List<List<(int node, int weight)>> graph, int root, int target)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(root, 0);
        List<int> distances = new List<int>();

        for (int i = 0; i < graph.Count; i++)
        {
            if (i == root)
            {
                distances.Add(0);
                minHeap.Enqueue(i, 0);
            }
            else
            {
                distances.Add(int.MaxValue);
                minHeap.Enqueue(i, int.MaxValue);
            }
        }

        while (minHeap.Count > 0)
        {
            minHeap.TryDequeue(out int node, out int _);
            foreach (var (neighbor, weight) in graph[node])
            {
                int distance = distances[node] + weight;
                if (distances[neighbor] <= distance)
                    continue;
                minHeap.Enqueue(neighbor, distance);
                distances[neighbor] = distance;
            }
        }

        return distances[target];
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
