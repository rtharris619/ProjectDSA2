namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class PartitionTwoEqualSumSubsets
{

    public static bool CanPartition(List<int> nums)
    {
        int sum = nums.Sum();
        if (sum % 2 != 0)
            return false;

        int n = nums.Count;
        int target = sum / 2;

        // Top down
        return DFS(nums, target, n, 0);
    }

    public static bool DFS(List<int> nums, int target, int i, int current)
    {
        if (current == target)
            return true;
        if (i == 0 || current > target)
            return false;

        var exists = DFS(nums, target, i - 1, current) || DFS(nums, target, i - 1, current + nums[i - 1]);

        return exists;
    }

    public static bool CanPartition2(List<int> nums)
    {
        int sum = nums.Sum();
        if (sum % 2 != 0)
            return false;

        int n = nums.Count;
        int target = sum / 2;

        // memo[i,j] = -1 -> Not processed
        // memo[i,j] =  0 -> False
        // memo[i,j] =  1 -> True

        int[,] memo = new int[n + 1, target + 1];
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= target; j++)
                memo[i, j] = -1;
        
        // Top down memoized with pruning
        return DFSMemo(nums, target, n, 0, memo);
    }

    public static bool DFSMemo(List<int> nums, int target, int i, int current, int[,] memo)
    {
        if (current == target)
            return true;

        if (i == 0 || current > target)
            return false;

        var memoResult = memo[i, current];
        if (memoResult != -1)
        {
            if (memoResult == 0)
                return false;
            if (memoResult == 1)
                return true;
        }

        var exists = DFSMemo(nums, target, i - 1, current, memo) 
            || DFSMemo(nums, target, i - 1, current + nums[i - 1], memo);

        if (exists)     
            memo[i, current] = 1;
        else
            memo[i, current] = 0;

        return exists;
    }

    public static bool CanPartition3(List<int> nums)
    {
        int sum = nums.Sum();
        if (sum % 2 != 0)
            return false;

        int n = nums.Count;

        int target = sum / 2;
        bool[,] dp = new bool[n + 1, target + 1];
        dp[0, 0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                if (j < nums[i - 1])
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                }
            }
        }

        return dp[n, target];
    }

    public static void Driver()
    {
        var nums = new List<int> { 1, 5, 11, 5 };
        var result = CanPartition3(nums);
        Console.WriteLine(result);
    }
}
