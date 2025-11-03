namespace ProjectDSA2.Algomonster.Backtracking;

public class Subsets
{
    private static void DFSNaive(List<int> nums, List<int> sequence, int index, List<List<int>> result)
    {
        if (index == nums.Count)
        {
            result.Add(new List<int>(sequence));
            return;
        }
        sequence.Add(nums[index]);
        DFSNaive(nums, sequence, index + 1, result);
        sequence.RemoveAt(sequence.Count - 1);
        DFSNaive(nums, sequence, index + 1, result);
    }

    private static void DFS(List<int> nums, List<int> sequence, int index, List<List<int>> result)
    {
        result.Add(new List<int>(sequence));
        for (int i = index; i < nums.Count; i++)
        {
            sequence.Add(nums[i]);
            DFS(nums, sequence, i + 1, result);
            sequence.RemoveAt(sequence.Count - 1);
        }
    }

    public static List<List<int>> Subs(List<int> nums)
    {
        var result = new List<List<int>>();
        DFS(nums, new List<int>(), 0, result);
        return result;
    }

    public static void Driver()
    {
        var nums = new List<int>() { 1, 2, 3 };
        var result = Subs(nums);
        foreach (var item in result)
        {
            Console.WriteLine("[" + string.Join(", ", item) + "]");
        }
    }
}
