namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class HouseRobber
{

    public static int Rob(List<int> nums)
    {
        if (nums.Count == 0) return 0;
        if (nums.Count <= 2) return nums.Max();

        int[] dp = new int[nums.Count];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Count; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
        }

        return dp[^1];
    }

    public static void Driver()
    {
        var nums = new List<int>
        {
            5, 1, 3, 100
        };
        var result = Rob(nums);
        Console.WriteLine(result);
    }
}
