namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class UniquePaths
{

    public static int Paths(int m, int n)
    {
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {            
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 1;
                else
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }

    /// <summary>
    /// Space Optimised Solution
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int Paths2(int m, int n)
    {
        int[] dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[^1];
    }

    public static void Driver()
    {
        int m = 5;
        int n = 3;

        var result = Paths2(m, n);
        Console.WriteLine(result);

        m = 2;
        n = 3;
        result = Paths2(m, n);
        Console.WriteLine(result);
    }
}
