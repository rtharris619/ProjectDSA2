namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class LargestDivisibleSubset
{

    public static int FindLargestSubset(List<int> nums)
    {
        nums.Sort();
        int n = nums.Count;
        int[] dp = new int[n];

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] % nums[i] == 0)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }

    public static int FindLargestSubset2(List<int> nums)
    {
        nums.Sort();
        int[] memo = new int[nums.Count];
        Array.Fill(memo, 0);

        int result = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            result = Math.Max(result, DFS(nums, i, memo));
        }
        return result;
    }

    public static int DFS(List<int> nums, int i, int[] memo)
    {
        if (i == 0)
        {
            return 1;
        }
        if (memo[i] > 0)
        {
            return memo[i];
        }

        int maxLength = 0;
        for (int j = 0; j < i; j++)
        {
            if (nums[i] % nums[j] == 0)
            {
                maxLength = Math.Max(maxLength, 1 + DFS(nums, j, memo));
            }
        }
        memo[i] = maxLength;
        return maxLength;
    }

    public static void Driver()
    {
        var nums = new List<int> { 1, 2, 4, 8 };
        var result = FindLargestSubset2(nums);
        Console.WriteLine(result);
    }
}
