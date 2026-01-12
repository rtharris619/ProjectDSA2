namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class MinCostClimbingStairs
{

    public static int MinCost(List<int> cost)
    {
        int[] dp = new int[cost.Count + 1];
        dp[0] = 0;
        dp[1] = 0;

        for (int i = 2; i <= cost.Count; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[^1];
    }

    public static int MinCost2(List<int> cost)
    {
        int n = cost.Count;
        int prev2 = 0;
        int prev1 = 0;

        for (int i = 2; i <= n; i++)
        {
            int curr = Math.Min(prev1 + cost[i - 1], prev2 + cost[i - 2]);
            (prev2, prev1) = (prev1, curr);
        }

        return prev1;
    }

    public static void Driver()
    {
        var cost = new List<int> { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
        var result = MinCost2(cost);
        Console.WriteLine(result);

        cost = new List<int> { 10, 15, 20 };
        result = MinCost2(cost);
        Console.WriteLine(result);
    }
}
