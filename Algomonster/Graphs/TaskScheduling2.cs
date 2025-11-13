namespace ProjectDSA2.Algomonster.Graphs;

public class TaskScheduling2
{
    private static Dictionary<string, int> GetIndegree(Dictionary<string, List<string>> graph)
    {
        Dictionary<string, int> indegree = new Dictionary<string, int>();

        foreach (string node in graph.Keys)
        {
            indegree.Add(node, 0);
        }

        foreach (string node in graph.Keys)
        {
            foreach (string neighbor in graph[node])
            {
                indegree[neighbor] += 1;
            }
        }

        return indegree;
    }

    private static Dictionary<string, List<string>> ConstructGraph(List<string> tasks, List<List<string>> requirements)
    {
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        foreach (string task in tasks)
        {
            graph.Add(task, new List<string>());
        }

        foreach (List<string> requirement in requirements)
        {
            string first = requirement[0];
            string second = requirement[1];

            graph[first].Add(second);
        }

        return graph;
    }

    public static int Scheduling2(List<string> tasks, List<int> times, List<List<string>> requirements)
    {
        int result = 0;

        Dictionary<string, List<string>> graph = ConstructGraph(tasks, requirements);
        Dictionary<string, int> indegree = GetIndegree(graph);

        Queue<string> queue = new Queue<string>();

        Dictionary<string, int> distances = new Dictionary<string, int>();
        foreach (string node in graph.Keys)
        {
            distances.Add(node, 0);
        }

        foreach (string node in indegree.Keys)
        {
            if (indegree[node] == 0)
            {
                queue.Enqueue(node);
                distances[node] = times[tasks.FindIndex(x => x == node)];
                result = Math.Max(result, distances[node]);
            }
        }
        
        while (queue.Count > 0)
        {
            string node = queue.Dequeue();

            foreach (string neighbor in graph[node])
            {
                indegree[neighbor] -= 1;
                distances[neighbor] = Math.Max(distances[neighbor], distances[node] + times[tasks.FindIndex(x => x == neighbor)]);
                result = Math.Max(result, distances[neighbor]);
                if (indegree[neighbor] == 0)
                {                   
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<string> tasks = new List<string>() { "a", "b", "c", "d" };
        List<int> times = new List<int>() { 1, 1, 2, 1 };
        List<List<string>> requirements = new List<List<string>>()
        {
            new() { "a", "b" },
            new() { "c", "b" },
            new() { "b", "d" },
        };

        int result = Scheduling2(tasks, times, requirements);
        Console.WriteLine(result);
    }
}
