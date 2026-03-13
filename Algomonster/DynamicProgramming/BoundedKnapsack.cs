namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class BoundedKnapsack
{

    public static int Knapsack(List<int> weights, List<int> values, List<int> quantities, int capacity)
    {
        int n = weights.Count;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[capacity + 1];
            Array.Fill(dp[i], 0);
        }

        for (int i = 1; i <= n; i++)
        {
            int weight = weights[i - 1];
            int value = values[i - 1];
            int quantity = quantities[i - 1];

            for (int j = 0; j <= capacity; j++)
            {
                // Try taking 0, 1, 2, ..., up to quantity copies
                for (int count = 0; count <= quantity; count++)
                {
                    if (count * weight <= j)
                    {
                        int prev = dp[i - 1][j - count * weight];
                        dp[i][j] = Math.Max(dp[i][j], prev + count * value);
                    }
                }
            }
        }

        return dp[n][capacity];
    }

    public static int Knapsack2(List<int> weights, List<int> values, List<int> quantities, int capacity)
    {
        // Step 1: Decompose each item into chunks
        int n = weights.Count;
        var expanded = new List<(int weight, int value)>();

        for (int i = 1; i <= n; i++)
        {
            int weight = weights[i - 1];
            int value = values[i - 1];
            int quantity = quantities[i - 1];
            int k = 1;
            while (k <= quantity)
            {
                expanded.Add((k * weight, k * value));
                quantity -= k;
                k *= 2;
            }
            if (quantity > 0) // remainder
            {
                expanded.Add((quantity * weight, quantity * value));
            }
        }

        // Step 2: Solve as 0/1 knapsack
        int[] dp = new int[capacity + 1];
        foreach (var (weight, value) in expanded)
        {
            for (int j = capacity; j > weight - 1; j--) // right-to-left
            {
                dp[j] = Math.Max(dp[j], dp[j - weight] + value);
            }
        }

        return dp[capacity];
    }

    public static void Driver()
    {
        List<int> weights =    [2, 3, 4];
        List<int> values =     [3, 4, 5];
        List<int> quantities = [3, 2, 1];
        int capacity = 10;

        int result = Knapsack2(weights, values, quantities, capacity);
        Console.WriteLine(result);
    }
}
