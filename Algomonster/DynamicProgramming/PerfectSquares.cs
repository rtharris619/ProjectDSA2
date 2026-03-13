namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class PerfectSquares
{

    public static int Squares(int n)
    {
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        int squareRoot = (int)Math.Sqrt(n);
        for (int i = 1; i <= squareRoot; i++)
        {
            int square = i * i;
            for (int j = square; j <= n; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j - square] + 1);
            }
        }

        return dp[n];
    }

    public static void Driver()
    {
        int n = 12;
        int result = Squares(n);
        Console.WriteLine(result);
    }
}
