namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class ClimbingStairs
{

    public static long ClimbStairs(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;

        int[] dp = new int[n];
        Array.Fill(dp, 0);

        dp[0] = 1;
        dp[1] = 2;

        for (int i = 2; i < n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[dp.Count() - 1];
    }

    public static long ClimbStairs2(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;

        long first = 1;
        long second = 2;

        for (int i = 2; i < n; i++)
        {
            long next = first + second;
            first = second;
            second = next;
        }

        return second;
    }

    public static void Driver()
    {
        int n = 3;
        long result = ClimbStairs2(n);
        Console.WriteLine(result);
    }
}
