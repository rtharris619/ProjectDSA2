namespace ProjectDSA2.Algomonster.Backtracking;

public class CombinationSum
{
    private static void DFS(List<int> candidates, int target, List<int> sequence, int sumSoFar, int startIndex, List<List<int>> result)
    {
        if (sumSoFar == target)
        {
            result.Add(new List<int>(sequence));
            return;
        }

        if (sumSoFar > target) return;

        for (int i = startIndex; i < candidates.Count; i++)
        {
            int candidate = candidates[i];
            sumSoFar += candidate;
            if (sumSoFar > target) break;
            sequence.Add(candidate);
            DFS(candidates, target, sequence, sumSoFar, i, result);
            sumSoFar -= candidate;
            sequence.RemoveAt(sequence.Count - 1);
        }
    }

    public static List<List<int>> Combinations(List<int> candidates, int target)
    {
        var result = new List<List<int>>();

        candidates.Sort();
        DFS(candidates, target, new List<int>(), 0, 0, result);

        return result;
    }

    public static void Driver()
    {
        var candidates = new List<int>() { 2, 3, 5 };
        var target = 8;
        var result = Combinations(candidates, target);

        foreach (var item in result)
        {
            Console.WriteLine(string.Join(", ", item));
        }
    }
}
