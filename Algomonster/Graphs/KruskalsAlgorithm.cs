using static ProjectDSA2.Helpers.UnionFindHelper;

namespace ProjectDSA2.Algomonster.Graphs;

public class KruskalsAlgorithm
{
    public class Edge
    {
        public int weight, a, b;

        public Edge(int weight, int a, int b)
        {
            this.weight = weight;
            this.a = a;
            this.b = b;
        }
    }

    // This function counts all of the edge weights to connect all nodes with minimum weights.
    public static int MinimumSpanningTree(int n, List<Edge> edges)
    {
        edges.Sort(Comparer<Edge>.Create((a, b) => a.weight - b.weight));
        UnionFind dsu = new UnionFind();
        int result = 0;
        int count = 0;

        foreach (Edge edge in edges)
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
        List<Edge> edges = new List<Edge>()
        {
            new Edge(1, 2, 1),
            new Edge(2, 5, 1),
            new Edge(4, 5, 2),
            new Edge(1, 5, 3),
            new Edge(3, 2, 3),
            new Edge(3, 4, 5),
            new Edge(4, 1, 6),
        };

        int result = MinimumSpanningTree(n, edges);
        Console.WriteLine(result);
    }
}
