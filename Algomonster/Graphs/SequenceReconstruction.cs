namespace ProjectDSA2.Algomonster.Graphs;

public class SequenceReconstruction
{
    private static Dictionary<int, int> FindIndegree(Dictionary<int, List<int>> graph)
    {
        Dictionary<int, int> indegree = new Dictionary<int, int>();

        foreach (var node in graph.Keys)
        {
            indegree[node] = 0;
        }

        foreach (var node in graph.Keys)
        {
            foreach (var neighbor in graph[node])
            {
                indegree[neighbor] = indegree.GetValueOrDefault(neighbor, 0) + 1;
            }
        }

        return indegree;
    }

    private static Dictionary<int, List<int>> PopulateGraph(int n, List<List<int>> seqs)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++)
        {
            graph.Add(i + 1, new List<int>()); // 1..6
        }

        foreach (List<int> seq in seqs)
        {
            for (int i = 0; i < seq.Count - 1; i++)
            {
                int first = seq[i];
                int second = seq[i + 1];
                graph[first].Add(second);
            }
        }

        return graph;
    }

    public static bool Reconstruction(List<int> original, List<List<int>> seqs)
    {
        List<int> result = new List<int>();

        Dictionary<int, List<int>> graph = PopulateGraph(original.Count, seqs);

        Dictionary<int, int> indegree = FindIndegree(graph);

        Queue<int> queue = new Queue<int>();

        foreach (int node in indegree.Keys)
        {
            if (indegree[node] == 0)
                queue.Enqueue(node);
        }

        while (queue.Count > 0)
        {
            if (queue.Count > 1)
                return false;

            int top = queue.Dequeue();
            result.Add(top);

            foreach (var neighbor in graph[top])
            {
                indegree[neighbor] -= 1;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return result.SequenceEqual(original);
    }

    public static void Driver()
    {
        List<int> original = new List<int>() { 4, 1, 5, 2, 6, 3 };
        List<List<int>> seqs = new List<List<int>>()
        {
            new() { 5, 2, 6, 3  },
            new() { 4, 1, 5, 2  },
        };
        bool result = Reconstruction(original, seqs);
        Console.WriteLine(result);
    }
}
