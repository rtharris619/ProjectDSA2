using ProjectDSA2.AdventOfCode.Helpers;
using static ProjectDSA2.Helpers.UnionFindHelper;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayEight;

public class PartTwo
{

    private static int Solve(List<string> input)
    {
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

        var added = new HashSet<(int i, int j)>();

        var disjointSetUnion = new UnionFind();
        var connectedPoints = new List<((int x, int y, int z), (int x, int y, int z))>();

        while (heap.Count > 0)
        {
            (int i, int j) = heap.Dequeue();
            if (!added.Add((i, j))) continue;

            graph[i].Add(j);
            graph[j].Add(i);

            if (disjointSetUnion.Find(i) != disjointSetUnion.Find(j))
            {
                disjointSetUnion.Union(i, j);
                connectedPoints.Add((points[i], points[j]));
            }
        }

        var lastConnectedPoint = connectedPoints.Last();
        return lastConnectedPoint.Item1.x * lastConnectedPoint.Item2.x;
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
        int result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        //Tests();

        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 8, trim: true);
        int result = Solve(input);
        Console.WriteLine(result);
    }
}
