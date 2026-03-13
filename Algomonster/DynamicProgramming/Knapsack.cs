namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class Knapsack
{

    // Brute force Top Down approach -> O(2^n)
    public static int KnapsackSolution(List<int> weights, List<int> values, int maxWeight)
    {
        return DFS(weights, values, maxWeight, weights.Count);
    }

    public static int DFS(List<int> weights, List<int> values, int remainingWeight, int n)
    {
        if (n == 0 || remainingWeight <= 0) return 0;

        if (weights[n - 1] > remainingWeight)
            return DFS(weights, values, remainingWeight, n - 1);

        return Math.Max(
                DFS(weights, values, remainingWeight - weights[n - 1], n - 1) + values[n - 1],
                DFS(weights, values, remainingWeight, n - 1)
            );
    }

    public static int KnapsackSolution2(List<int> weights, List<int> values, int maxWeight)
    {
        int n = weights.Count;
        int[][] memo = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            memo[i] = new int[maxWeight + 1];
            Array.Fill(memo[i], -1);
        }

        return DFSMemo(weights, values, maxWeight, n, memo);
    }

    public static int DFSMemo(List<int> weights, List<int> values, int remainingWeight, int n, int[][] memo)
    {
        if (n == 0 || remainingWeight == 0)
            return 0;

        if (memo[n][remainingWeight] != -1)
            return memo[n][remainingWeight];

        int result;
        if (weights[n - 1] > remainingWeight)
        {
            result = DFSMemo(weights, values, remainingWeight, n - 1, memo);
        }
        else
        {
            result = Math.Max(
                DFSMemo(weights, values, remainingWeight - weights[n - 1], n - 1, memo) + values[n - 1], 
                DFSMemo(weights, values, remainingWeight, n - 1, memo)
            );
        }

        memo[n][remainingWeight] = result;
        return result;
    }

    public static int KnapsackSolution3(List<int> weights, List<int> values, int maxWeight)
    {
        int n = weights.Count;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[maxWeight + 1];
            Array.Fill(dp[i], 0);
        }

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= maxWeight; w++)
            {
                if (w < weights[i - 1])
                {
                    dp[i][w] = dp[i - 1][w];
                }
                else
                {
                    dp[i][w] = Math.Max(values[i - 1] + dp[i - 1][w - weights[i - 1]], dp[i - 1][w]);
                }
            }
        }

        return dp[n][maxWeight];
    }

    public static void Driver()
    {
        int result = KnapsackSolution3(
            [3, 4, 7], 
            [4, 5, 8], 
            7);
        Console.WriteLine(result);
    }
}
