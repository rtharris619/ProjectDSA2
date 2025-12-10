using System.Linq.Expressions;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayEight;

public class PartOne
{

    private static long Solve(List<string> input)
    {
        long result = 0;

        // step 1: Append coords to the Min Heap

        var minHeap = new PriorityQueue<(string from, string to), double>();

        for (int i = 0; i < input.Count - 1; i++) // go up until 2nd last item
        {
            string line1 = input[i].Trim();
            string[] coord1 = line1.Split(",", StringSplitOptions.RemoveEmptyEntries);
            double x1 = double.Parse(coord1[0]);
            double y1 = double.Parse(coord1[1]);
            double z1 = double.Parse(coord1[2]);

            for (int j = i + 1; j < input.Count; j++)
            {
                string line2 = input[j].Trim();
                string[] coord2 = line2.Split(",", StringSplitOptions.RemoveEmptyEntries);
                double x2 = double.Parse(coord2[0]);
                double y2 = double.Parse(coord2[1]);
                double z2 = double.Parse(coord2[2]);

                double euclideanDistance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));

                minHeap.Enqueue((line1, line2), euclideanDistance);
            }
        }

        // step 2: Build graph until we have (inputSize / 2 connections) [10 for test, 500 for puzzle input]

        // 

        var graph = new Dictionary<string, List<string>>();
        int targetConnections = input.Count / 2;
        int currentConnections = 0;

        while (currentConnections < targetConnections)
        {
            (string from, string to) = minHeap.Dequeue();

            // check for existing connection in graph...
            if (graph.Count > 0)
            {
                if (graph.ContainsKey(from) && graph[from].Contains(to)) continue;
                if (graph.ContainsKey(to) && graph[to].Contains(from)) continue;
            }

            if (!graph.ContainsKey(from))
            {
                graph[from] = new List<string>();
            }
            
            graph[from].Add(to);
            currentConnections++;
        }

        return result;
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
        long result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        Tests();
    }
}
