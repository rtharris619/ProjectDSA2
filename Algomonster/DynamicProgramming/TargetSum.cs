namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class TargetSum
{

    public static int Target(List<int> nums, int target)
    {
        var total = nums.Sum();

        if ((total + target) % 2 != 0)
        {
            return 0;
        }
        if (Math.Abs(target) > total)
        {
            return 0;
        }

        var subsetSum = (total + target) / 2;
        var memo = new Dictionary<string, int>();

        return DFS(nums, target, nums.Count, 0, subsetSum, memo);
    }

    public static int DFS(List<int> nums, int target, int i, int currentSum, int subsetSum, Dictionary<string, int> memo)
    {
        if (i == 0)
        {
            if (currentSum == subsetSum)
                return 1;
            else
                return 0;
        }

        string key = $"{i},{currentSum}";
        if (memo.ContainsKey(key))
            return memo[key];

        int result = DFS(nums, target, i - 1, currentSum, subsetSum, memo) + DFS(nums, target, i - 1, currentSum + nums[i - 1], subsetSum, memo);
        memo[key] = result;
        return result;
    }

    public static int Target2(List<int> nums, int target)
    {
        if (nums.Sum() < Math.Abs(target)) 
            return 0;

        return DFSMemo(nums, target, 0, 0, new Dictionary<string, int>());
    }

    public static int DFSMemo(List<int> nums, int target, int i, int currentSum, Dictionary<string, int> memo)
    {
        if (i == nums.Count)
        {
            if (currentSum == target)
                return 1;
            else
                return 0;
        }

        string key = $"{i},{currentSum}";
        if (memo.ContainsKey(key))
            return memo[key];

        int result = DFSMemo(nums, target, i + 1, currentSum - nums[i], memo) + DFSMemo(nums, target, i + 1, currentSum + nums[i], memo);
        memo[key] = result;
        return result;
    }

    public static void Driver()
    {
        var nums = new List<int> { 1, 1, 1, 1, 1 };
        var target = 3;
        var result = Target(nums, target);
        Console.WriteLine(result);
    }
}
