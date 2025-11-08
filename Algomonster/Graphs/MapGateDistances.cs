namespace ProjectDSA2.Algomonster.Graphs;

public class MapGateDistances
{
    private static IEnumerable<(int, int)> GetNeighbors((int row, int col) node, List<List<int>> dungeonMap)
    {
        List<int> deltaRows = new List<int>()
        {
            0, -1, 0, 1
        };
        List<int> deltaCols = new List<int>()
        {
            -1, 0, 1, 0
        };

        for (int i = 0; i < 4; i++)
        {
            var neighborRow = deltaRows[i] + node.row;
            var neighborCol = deltaCols[i] + node.col;

            if (neighborRow >= 0 && neighborCol >= 0 
                && neighborRow < dungeonMap.Count 
                && neighborCol < dungeonMap[0].Count
                && dungeonMap[neighborRow][neighborCol] == int.MaxValue)
            {
                yield return (neighborRow, neighborCol);
            }
        }
    }

    private static List<List<int>> BFS(List<List<int>> dungeonMap, List<(int, int)> gates)
    {
        Queue<(int, int)> queue = new Queue<(int, int)> ();
        
        foreach (var gate in gates)
        {
            queue.Enqueue(gate);
        }

        int distance = 0;

        while (queue.Count > 0)
        {
            int n = queue.Count;
            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                dungeonMap[node.Item1][node.Item2] = Math.Min(dungeonMap[node.Item1][node.Item2], distance);

                foreach (var neighbor in GetNeighbors(node, dungeonMap))
                {
                    queue.Enqueue(neighbor);
                }
            }
            distance++;
        }

        return dungeonMap;
    }

    private static List<(int, int)> GetGates(List<List<int>> dungeonMap)
    {
        List<(int, int)> gates = new List<(int, int)>();

        for (int i = 0; i < dungeonMap.Count; i++)
        {
            for (int j = 0; j < dungeonMap[i].Count; j++)
            {
                if (dungeonMap[i][j] == 0)
                {
                    gates.Add((i, j));
                }
            }
        }

        return gates;
    }

    public static List<List<int>> Distances(List<List<int>> dungeonMap)
    {
        List<(int, int)> gates = GetGates(dungeonMap);
        return BFS(dungeonMap, gates);
    }

    public static void Driver()
    {
        const int INF = int.MaxValue;
        int[][] dungeonMapArray = [
            [INF,  -1,   0, INF],
            [INF, INF, INF,  -1],
            [INF, -1,  INF,  -1],
            [0,   -1,  INF, INF]
        ];

        List<List<int>> dungeonMap = dungeonMapArray.Select(x => x.ToList()).ToList();
        List<List<int>> result = Distances(dungeonMap);
        foreach (var item in result)
        {
            Console.WriteLine("[" + string.Join(", ", item) + "]");
        }
    }
}
