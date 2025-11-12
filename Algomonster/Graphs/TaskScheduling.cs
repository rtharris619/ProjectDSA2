using System.Threading.Tasks;

namespace ProjectDSA2.Algomonster.Graphs;

public class TaskScheduling
{
    private static Dictionary<string, int> FindIndegree(Dictionary<string, List<string>> graph)
    {
        Dictionary<string, int> indegree = new Dictionary<string, int>();

        foreach (var node in graph.Keys)
        {
            indegree.Add(node, 0);
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

    private static Dictionary<string, List<string>> PopulateGraph(List<string> tasks, List<List<string>> requirements)
    {
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        foreach (string task in tasks)
        {
            graph.Add(task, new List<string>());
        }

        foreach (var requirement in requirements)
        {
            string first = requirement[0];
            string second = requirement[1];

            graph[first].Add(second);
        }
        return graph;
    }

    public static List<string> Scheduling(List<string> tasks, List<List<string>> requirements)
    {
        List<string> result = new List<string>();

        Dictionary<string, List<string>> graph = PopulateGraph(tasks, requirements);
        Queue<string> queue = new Queue<string>();

        var indegree = FindIndegree(graph);

        foreach (var node in indegree.Keys)
        {
            if (indegree[node] == 0)
                queue.Enqueue(node);
        }

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            result.Add(node);

            foreach (var neighbor in graph[node])
            {
                indegree[neighbor] -= 1;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }        

        return result;
    }

    public static void Driver()
    {
        List<string> tasks = new List<string>() { "a", "b", "c", "d" };
        List<List<string>> requirements = new List<List<string>>()
        {
            new() { "a", "b" },
            new() { "c", "b" },
            new() { "b", "d" },
        };
        List<string> result = Scheduling(tasks, requirements);
        Console.WriteLine(string.Join(", ", result));
    }
}
