using static ProjectDSA2.Helpers.UnionFindHelper;

namespace ProjectDSA2.Algomonster.Graphs;

public class MinimumSpanningTreeForest
{
    public static int MstForest(int trees, List<List<int>> pairs)
    {
        int result = 0;

        pairs.Sort(Comparer<List<int>>.Create((a, b) => a[2].CompareTo(b[2])));
        UnionFind disjointSet = new UnionFind();

        foreach (List<int> pair in pairs)
        {
            int a = pair[0];
            int b = pair[1];
            int weight = pair[2];

            if (disjointSet.Find(a) != disjointSet.Find(b))
            {
                disjointSet.Union(a, b);
                result += weight;
            }
        }

        return result;
    }

    public static void Driver()
    {
        int trees = 5;
        List<List<int>> pairs = new List<List<int>>()
        {
            new() { 1, 2, 1 },
            new() { 2, 4, 2 },
            new() { 3, 5, 3 },
            new() { 4, 4, 4 },
        };

        int result = MstForest(trees, pairs);
        Console.WriteLine(result);
    }
}
