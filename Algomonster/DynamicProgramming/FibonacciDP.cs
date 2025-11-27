namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class FibonacciDP
{
    public static int FibBottomUp(int n)
    {
        if (n == 0 || n == 1)
            return n;

        List<int> dp = new List<int>() { 0, 1 };

        for (int i = 2; i < n + 1; i++)
        {
            dp.Add(dp[i - 1] + dp[i - 2]);
        }

        return dp[dp.Count - 1];
    }

    public static int FibTopDown(int n, int[] memo)
    {
        if (memo[n] != 0)
            return memo[n];
        if (n == 0 || n == 1)
            return n;

        int result = FibTopDown(n - 1, memo) + FibTopDown(n - 2, memo);
        memo[n] = result;
        return result;
    }

    public static void Driver()
    {
        int n = 6;
        int result = FibBottomUp(n);
        Console.WriteLine(result);

        int[] memo = new int[n + 1];
        Array.Fill(memo, 0);
        result = FibTopDown(n, memo);
        Console.WriteLine(result);
    }
}
