namespace ProjectDSA2.Algomonster.Graphs;

public class IsValidCourseSchedule
{
    private static Dictionary<int, List<int>> ConstructGraph(int n, List<List<int>> prerequisites)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
        }

        foreach (var preReq in prerequisites)
        {
            int first = preReq[1];
            int second = preReq[0];
            graph[first].Add(second);
        }

        return graph;
    }

    private static Dictionary<int, int> GetIndegree(Dictionary<int, List<int>> graph)
    {
        Dictionary<int, int> indegree = new Dictionary<int, int>();

        foreach (int node in graph.Keys)
        {
            indegree.Add(node, 0);
        }

        foreach (var node in graph.Keys)
        {
            foreach (var neighbor in graph[node])
            {
                indegree[neighbor] += 1;
            }
        }

        return indegree;
    }

    public static bool IsValid(int n, List<List<int>> prerequisites)
    {
        var nodes = new List<int>();

        var graph = ConstructGraph(n, prerequisites);
        var indegree = GetIndegree(graph);

        Queue<int> queue = new Queue<int>();

        foreach (int node in indegree.Keys)
        {
            if (indegree[node] == 0)
            {
                queue.Enqueue(node);
            }
        }

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            nodes.Add(node);

            foreach (int neighbor in graph[node])
            {
                indegree[neighbor] -= 1;
                if (indegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return nodes.Count == graph.Count;
    }

    public static void Driver()
    {
        int n = 3;
        List<List<int>> prerequisites = new List<List<int>>()
        {
            new() { 0, 1 },
            new() { 0, 2 },
        };

        bool result = IsValid(n, prerequisites);
        Console.WriteLine(result);
    }
}
