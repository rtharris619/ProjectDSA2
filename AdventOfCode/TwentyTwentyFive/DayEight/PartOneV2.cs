using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayEight;

public class PartOneV2
{

    private static int Solve(List<string> input, int connections)
    {
        int result = 0;

        // step 1: Append coords to the Min Heap        
        var points = new List<(int x, int y, int z)>(input.Count);

        for (int idx = 0; idx < input.Count; idx++)
        {
            string line = input[idx].Trim();
            string[] parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);
            points.Add((x, y, z));
        }

        int n = points.Count;

        var heap = new PriorityQueue<(int i, int j), double>();

        for (int i = 0; i < n - 1; i++) // go up until 2nd last item
        {
            (int x1, int y1, int z1) = points[i];
            for (int j = i + 1; j < n; j++)
            {
                (int x2, int y2, int z2) = points[j];
                double euclideanDistance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));

                heap.Enqueue((i, j), euclideanDistance);
            }
        }

        // step 2: Build graph from the shortest paths min heap

        var graph = new Dictionary<int, List<int>>(n);
        for (int i = 0; i < n; i++) graph[i] = [];

        int currentConnections = 0;
        var added = new HashSet<(int i, int j)>();

        while (currentConnections < connections)
        {
            (int i, int j) = heap.Dequeue();
            if (!added.Add((i, j))) continue;

            graph[i].Add(j);
            graph[j].Add(i);
            currentConnections++;
        }

        // step 3: count connected components

        var visited = new bool[n];
        var counts = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                int count = DFSCount(i, graph, visited);
                counts.Add(count);
            }
        }

        counts.Sort((a, b) => b.CompareTo(a));
        result = counts[0] * counts[1] * counts[2];
        return result;
    }

    private static int BFSCount(int start, Dictionary<int, List<int>> graph, bool[] visited)
    {
        int count = 0;
        var queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int top = queue.Dequeue();
            count++;
            foreach (var neighbor in graph[top])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return count;
    }

    private static int DFSCount(int start, Dictionary<int, List<int>> graph, bool[] visited)
    {
        int count = 0;
        var stack = new Stack<int>();
        stack.Push(start);
        visited[start] = true;

        while (stack.Count > 0)
        {
            int top = stack.Pop();
            count++;

            foreach (int neighbor in graph[top])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    stack.Push(neighbor);
                }
            }
        }

        return count;
    }

    private static void Tests()
    {
        var input = new List<string>()
        {
            "162,817,812",
            "57,618,57  ",
            "906,360,560",
            "592,479,940",
            "352,342,300",
            "466,668,158",
            "542,29,236 ",
            "431,825,988",
            "739,650,466",
            "52,470,668 ",
            "216,146,977",
            "819,987,18 ",
            "117,168,530",
            "805,96,715 ",
            "346,949,466",
            "970,615,88 ",
            "941,993,340",
            "862,61,35  ",
            "984,92,344 ",
            "425,690,689",
        };
        int result = Solve(input, 10);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        Tests();

        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 8, trim: true);
        int result = Solve(input, 1000);
        Console.WriteLine(result);
    }
}
