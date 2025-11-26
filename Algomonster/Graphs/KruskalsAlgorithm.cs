using static ProjectDSA2.Helpers.GraphHelper;
using static ProjectDSA2.Helpers.UnionFindHelper;

namespace ProjectDSA2.Algomonster.Graphs;

public class KruskalsAlgorithm
{   
    // This function counts all of the edge weights to connect all nodes with minimum weights.
    public static int MinimumSpanningTree(int n, List<WeightedEdge> edges)
    {
        edges.Sort(Comparer<WeightedEdge>.Create((a, b) => a.weight - b.weight));
        UnionFind dsu = new UnionFind();
        int result = 0;
        int count = 0;

        foreach (WeightedEdge edge in edges)
        {
            if (dsu.Find(edge.a) != dsu.Find(edge.b))
            {
                dsu.Union(edge.a, edge.b);
                result += edge.weight;
                count++;
                if (count == n - 1) 
                    break;
            }
        }

        return result;
    }

    public static void Driver()
    {
        int n = 5;
        List<WeightedEdge> edges = new List<WeightedEdge>()
        {
            new WeightedEdge(1, 2, 1),
            new WeightedEdge(2, 5, 1),
            new WeightedEdge(4, 5, 2),
            new WeightedEdge(1, 5, 3),
            new WeightedEdge(3, 2, 3),
            new WeightedEdge(3, 4, 5),
            new WeightedEdge(4, 1, 6),
        };

        int result = MinimumSpanningTree(n, edges);
        Console.WriteLine(result);
    }
}
