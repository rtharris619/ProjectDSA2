namespace ProjectDSA2.Algomonster.Graphs;

public class TopologicalSort
{
    private static Dictionary<int, int> FindInDegree(Dictionary<int, List<int>> graph)
    {
        Dictionary<int, int> indegree = new Dictionary<int, int>();

        foreach (var node in graph.Keys)
        {
            indegree.Add(node, 0);
        }

        foreach (int node in graph.Keys)
        {
            foreach (int neighbor in graph[node])
            {
                indegree[neighbor] = indegree.GetValueOrDefault(neighbor, 0) + 1;
            }
        }

        return indegree;
    }

    private static bool ContainsCycle(Dictionary<int, List<int>> graph)
    {
        List<int> nodes = new List<int>();
        Queue<int> queue = new Queue<int>();

        Dictionary<int, int> indegree = FindInDegree(graph);

        foreach (int node in indegree.Keys)
        {
            if (indegree[node] == 0)
                queue.Enqueue(node);
        }

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            nodes.Add(node);

            foreach (int neighbor in graph[node])
            {
                indegree[neighbor] -= 1;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return nodes.Count != graph.Count;
    }

    public static void Driver()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>()
        {
            { 4, new() { 2 } },
            { 5, new() { 2 } },
            { 6, new() { 3 } },
            { 2, new() { 1 } },
            { 3, new() { 1 } },
            { 1, new() {   } },
        };

        bool result = ContainsCycle(graph);
        Console.WriteLine(result);
    }
}
