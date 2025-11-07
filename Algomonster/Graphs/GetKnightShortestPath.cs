namespace ProjectDSA2.Algomonster.Graphs;

public class GetKnightShortestPath
{
    public static IEnumerable<(int, int)> GetNeighbors((int row, int col) square)
    {
        List<int> rowDeltas = new List<int>() 
        { 
            -1, -2, -2, -1, 1, 2, 2, 1
        };
        List<int> colDeltas = new List<int>()
        {
            -2, -1, 1, 2, 2, 1, -1, -2
        };

        for (int i = 0; i < 8; i++)
        {
            int neighborRow = square.row + rowDeltas[i];
            int neighborCol = square.col + colDeltas[i];

            yield return (neighborRow, neighborCol);
        }
    }

    public static int BFS(int x, int y)
    {
        if (x == 0 && y == 0) return 0;

        int result = 0;
        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        visited.Add((0, 0));
        queue.Enqueue((0, 0));

        while (queue.Count > 0)
        {
            int n = queue.Count;
            for (int i = 0; i < n; i++)
            {
                var (row, col) = queue.Dequeue();
                if (row == x && col == y)
                    return result;

                foreach (var neighbor in GetNeighbors((row, col)))
                {
                    if (visited.Contains(neighbor))
                        continue;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }

            result++;
        }

        return result;
    }

    public static int GetShortestPath(int x, int y)
    {
        return BFS(x, y);
    }

    public static void Driver()
    {
        int x = 5;
        int y = 5;

        int result = GetShortestPath(x, y);
        Console.WriteLine(result);
    }
}
