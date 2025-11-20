using System.Threading;

namespace ProjectDSA2.Algomonster.Graphs;

public class AlienDictionary
{
    public static Dictionary<char, int> FindIndegree(Dictionary<char, List<char>> graph)
    {
        Dictionary<char, int> indegree = new Dictionary<char, int>();

        foreach (var node in graph.Keys)
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

    public static List<char> TopologicalSort(Dictionary<char, List<char>> graph)
    {
        List<char> result = new List<char>();

        PriorityQueue<char, char> minHeap = new PriorityQueue<char, char>();
        Dictionary<char, int> indegree = FindIndegree(graph);

        foreach (char node in indegree.Keys)
        {
            if (indegree[node] == 0)
            {
                minHeap.Enqueue(node, node);
            }
        }

        while (minHeap.Count > 0)
        {
            char node = minHeap.Dequeue();
            result.Add(node);

            foreach (char neighbor in graph[node])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                {
                    minHeap.Enqueue(neighbor, neighbor);
                }
            }
        }

        if (indegree.Any(x => x.Value != 0))
            return new List<char>();

        return result;
    }

    public static Dictionary<char, List<char>> InitGraph(List<string> words)
    {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();

        foreach (var word in words)
        {
            foreach (var character in word)
            {
                if (!graph.ContainsKey(character))
                {
                    graph[character] = [];
                }
            }
        }

        return graph;
    }

    public static string AlienOrder(List<string> words)
    {
        var graph = InitGraph(words);

        string previous = words[0];
        for (int i = 1; i < words.Count; i++)
        {
            string current = words[i];
            int j = 0;
            while (j < previous.Length && j < current.Length)
            {
                if (previous[j] != current[j])
                {
                    if (!graph[previous[j]].Contains(current[j]))
                    {
                        graph[previous[j]].Add(current[j]);
                        break;
                    }
                }
                j++;
            }
            previous = current;
        }

        var result = TopologicalSort(graph);

        return result.Count > 0 ? string.Join("", result) : "";
    }

    public static void Driver()
    {
        List<string> words = new List<string>()
        {
            "wrt", "wrf", "er", "ett", "rftt"
        };
        string result = AlienOrder(words);
        Console.WriteLine(result);

        words = new List<string>()
        {
            "she", "sell", "seashell", "seashore", "seahorse", "on", "a"
        };
        result = AlienOrder(words);
        Console.WriteLine(result);
    }
}
