namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class DivisorGame
{

    public static bool Game(int n)
    {
        if (n == 1) return false;

        bool[] dp = new bool[n + 1];
        Array.Fill(dp, false);

        for (int i = 2; i < n + 1; i++)
        {
            for (int j = 1; j < i; j++)
            {
                if (i % j == 0)
                {
                    dp[i] = dp[i] || !dp[i - j];
                }
            }
        }

        return dp[^1];
    }

    public static bool Game2(int n)
    {
        return n % 2 == 0;
    }

    public static void Driver()
    {
        int n = 6;
        var result = Game(n);
        Console.WriteLine(result);
    }
}
