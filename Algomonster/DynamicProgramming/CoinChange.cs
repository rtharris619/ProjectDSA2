namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class CoinChange
{

    public static int CoinGame(List<int> coins, int amount)
    {
        var memo = new Dictionary<string, int>();
        var result = DFSMemo(coins, amount, coins.Count, memo);
        return result == int.MaxValue ? -1 : result;
    }

    public static int DFSMemo(List<int> coins, int amount, int i, Dictionary<string, int> memo)
    {
        if (amount == 0)
            return 0;

        if (i == 0 || amount < 0)
            return int.MaxValue;        

        string key = $"{i},{amount}";
        if (memo.TryGetValue(key, out int value))
            return value;

        int skip = DFSMemo(coins, amount, i - 1, memo);
        int use = DFSMemo(coins, amount - coins[i - 1], i, memo);

        if (use != int.MaxValue)
            use++;
        memo[key] = Math.Min(skip, use);
        return memo[key];
    }

    public static int CoinGame2(List<int> coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            for (int j = 0; j < coins.Count; j++)
            {
                if (i - coins[j] >= 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }

        return dp[amount];
    }

    public static void Driver()
    {
        var coins = new List<int> { 1, 2, 5 };
        int amount = 11;
        var result = CoinGame2(coins, amount);
        Console.WriteLine(result);
    }
}
