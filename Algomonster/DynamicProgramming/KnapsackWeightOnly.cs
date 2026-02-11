namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class KnapsackWeightOnly
{

    /// <summary>
    /// Brute Force Solution
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static List<int> Knapsack(List<int> weights)
    {
        var set = new HashSet<int>();
        DFS(weights, weights.Count, 0, set);
        return set.ToList();
    }

    public static void DFS(List<int> weights, int n, int total, HashSet<int> set)
    {
        if (n == 0)
        {
            set.Add(total);
            return;
        }

        DFS(weights, n - 1, total, set);
        DFS(weights, n - 1, total + weights[n - 1], set);
    }

    /// <summary>
    /// Memoized Solution
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static List<int> Knapsack2(List<int> weights)
    {
        var set = new HashSet<int>();
        var totalWeight = weights.Sum();
        var n = weights.Count;
        bool[,] memo = new bool[n + 1, totalWeight + 1];

        DFSMemo(weights, n, 0, set, memo);
        return set.ToList();
    }

    public static void DFSMemo(List<int> weights, int n, int total, HashSet<int> set, bool[,] memo)
    {
        if (n == 0)
        {
            set.Add(total);
            return;
        }
        if (memo[n, total])
        {
            return;
        }

        DFSMemo(weights, n - 1, total, set, memo);
        DFSMemo(weights, n - 1, total + weights[n - 1], set, memo);
        memo[n, total] = true;
    }

    /// <summary>
    /// DP Solution
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static List<int> Knapsack3(List<int> weights)
    {
        int n = weights.Count;
        int totalWeight = weights.Sum();
        bool[,] dp = new bool[n + 1, totalWeight + 1];
        dp[0, 0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= totalWeight; w++)
            {
                dp[i, w] = dp[i, w] || dp[i - 1, w];
                if (w - weights[i - 1] >= 0)
                {
                    dp[i, w] = dp[i, w] || dp[i - 1, w - weights[i - 1]];
                }
            }
        }

        var answer = new List<int>();
        for (int w = 0; w <= totalWeight; w++)
        {
            if (dp[n, w])
            {
                answer.Add(w);
            }
        }
        return answer;
    }

    /// <summary>
    /// Space Optimised DP Solution
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static List<int> Knapsack4(List<int> weights)
    {
        int n = weights.Count;
        int totalWeight = weights.Sum();
        bool[,] dp = new bool[2, totalWeight + 1];
        // dp[0] is prev
        // dp[1] is cur
        dp[0, 0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= totalWeight; w++)
            {
                dp[1, w] = dp[1, w] || dp[0, w];
                if (w - weights[i - 1] >= 0)
                {
                    dp[1, w] = dp[1, w] || dp[0, w - weights[i - 1]];
                }
            }
            for (int w = 0; w <= totalWeight; w++)
            {
                dp[0, w] = dp[1, w];
            }
        }

        var answer = new List<int>();
        for (int w = 0; w <= totalWeight; w++)
        {
            if (dp[0, w])
            {
                answer.Add(w);
            }
        }
        return answer;
    }

    public static void Driver()
    {
        var weights = new List<int> { 1, 3, 3, 5 };
        var result = Knapsack4(weights);
        Console.WriteLine(string.Join(',', result));
    }
}
