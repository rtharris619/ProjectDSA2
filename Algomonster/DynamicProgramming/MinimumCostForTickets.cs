namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class MinimumCostForTickets
{

    public static int MinimumCost(List<int> days, List<int> costs)
    {
        var travelDays = new HashSet<int>(days);
        int lastDay = days[^1];
        int[] dp = new int[lastDay + 1];

        for (int day = 1; day <= lastDay; day++) 
        {
            if (!travelDays.Contains(day))
            {
                dp[day] = dp[day - 1];
            }
            else
            {
                int cost1 = dp[day - 1] + costs[0];
                int cost7 = dp[day > 7 ? day - 7 : 0] + costs[1];
                int cost30 = dp[day > 30 ? day - 30 : 0] + costs[2];

                dp[day] = Math.Min(cost1, Math.Min(cost7, cost30));
            }
        }

        return dp[lastDay];
    }

    public static void Driver()
    {
        var days = new List<int> { 1, 4, 6, 7, 8, 20 };
        var costs = new List<int> { 2, 7, 15 };

        var result = MinimumCost(days, costs);
        Console.WriteLine(result);
    }
}
