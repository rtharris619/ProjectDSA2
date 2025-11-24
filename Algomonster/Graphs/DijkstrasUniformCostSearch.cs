namespace ProjectDSA2.Algomonster.Graphs;

public class DijkstrasUniformCostSearch
{
    public static int BFS(List<List<(int node, int weight)>> graph, int root, int target)
    {
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        priorityQueue.Enqueue(root, 0);

        int[] distances = new int[graph.Count];
        Array.Fill(distances, int.MaxValue);
        distances[root] = 0;

        while (priorityQueue.Count > 0)
        {
            priorityQueue.TryDequeue(out int node, out int distance);
            if (node == target)
                return distance;
            if (distance > distances[node])
                continue;

            foreach ((int neighbor, int weight) in graph[node])
            {
                distance = distances[node] + weight;
                if (distances[neighbor] <= distance)
                    continue;
                priorityQueue.Enqueue(neighbor, distance);
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
