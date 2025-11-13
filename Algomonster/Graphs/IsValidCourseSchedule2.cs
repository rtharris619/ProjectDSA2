// This showcases the recursive DFS solution.

namespace ProjectDSA2.Algomonster.Graphs;

public class IsValidCourseSchedule2
{
    private enum State
    {
        ToVisit = 0,
        Visiting = 1,
        Visited = 2,
    }

    private static Dictionary<int, List<int>> ConstructGraph(List<List<int>> prerequisites)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        foreach (var preReq in prerequisites)
        {
            if (!graph.ContainsKey(preReq[0]))
            {
                graph.Add(preReq[0], new List<int>());
            }
            graph[preReq[0]].Add(preReq[1]);
        }

        return graph;
    }

    private static bool DFS(int start, Dictionary<int, List<int>> graph, State[] states)
    {
        states[start] = State.Visiting;

        if (graph.ContainsKey(start))
        {
            foreach (int neighbor in graph[start])
            {
                if (states[neighbor] == State.Visited) 
                    continue;
                if (states[neighbor] == State.Visiting)
                    return false;
                if (!DFS(neighbor, graph, states))
                    return false;
            }
        }

        states[start] = State.Visited;
        return true;
    }

    public static bool IsValid(int n, List<List<int>> prerequisites)
    {
        Dictionary<int, List<int>> graph = ConstructGraph(prerequisites);
        State[] states = new State[n];
        Array.Fill(states, State.ToVisit);

        for (int i = 0; i < n; i++)
        {
            bool dfsResult = DFS(i, graph, states);
            if (!dfsResult)
                return false;
        }

        return true;
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
