namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class CoinChangeTwo
{

    public static int CoinGame(List<int> coins, int amount)
    {
        return DFSMemo(coins, amount, coins.Count, new Dictionary<string, int>());
    }

    public static int DFSMemo(List<int> coins, int amount, int i, Dictionary<string, int> memo)
    {
        if (amount == 0)
            return 1;
        if (i == 0 || amount < 0)
            return 0;

        string key = $"{i},{amount}";
        if (memo.ContainsKey(key))
            return memo[key];

        int result = DFSMemo(coins, amount, i - 1, memo) + DFSMemo(coins, amount - coins[i - 1], i, memo);
        memo[key] = result;
        return result;
    }

    public static int CoinGame2(List<int> coins, int amount)
    {
        int n = coins.Count;
        int[,] dp = new int[n + 1, amount + 1];
        dp[0, 0] = 1;
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= amount; j++)
            {
                dp[i, j] = dp[i - 1, j];
                if (j - coins[i - 1] >= 0)
                {
                    dp[i, j] += dp[i, j - coins[i - 1]];
                }
            }
        }

        return dp[n, amount];
    }

    public static void Driver()
    {
        var coins = new List<int> { 1, 2, 5 };
        var amount = 5;
        var result = CoinGame2(coins, amount);
        Console.WriteLine(result);
    }
}
