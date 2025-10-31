namespace ProjectDSA2.Algomonster.Backtracking;

public class CoinChange
{
    private static int DFS(List<int> coins, int target, int sum)
    {
        if (sum == target)
        {
            return 0;
        }
        if (sum > target)
        {
            return int.MaxValue;
        }

        int result = int.MaxValue;

        foreach (int coin in coins) 
        {
            var dfsResult = DFS(coins, target, sum + coin);
            if (dfsResult == int.MaxValue) continue;
            result = Math.Min(result, dfsResult + 1);
        }

        return result;
    }

    private static int DFSMemo(List<int> coins, int target, int sum, int[] memo)
    {
        if (sum == target)
        {
            return 0;
        }
        if (sum > target)
        {
            return int.MaxValue;
        }
        if (memo[sum] != -1)
        {
            return memo[sum];
        }

        int result = int.MaxValue;

        foreach (int coin in coins)
        {
            var dfsResult = DFSMemo(coins, target, sum + coin, memo);
            if (dfsResult == int.MaxValue) continue;
            result = Math.Min(result, dfsResult + 1);
        }

        memo[sum] = result;
        return result;
    }

    public static int Change(List<int> coins, int amount)
    {
        int[] memo = new int[amount + 1];
        Array.Fill(memo, -1);
        var result = DFSMemo(coins, amount, 0, memo);
        return result == int.MaxValue ? -1 : result;
    }

    public static void Driver()
    {
        var coins = new List<int>() { 1, 2, 5 };
        var amount = 11;
        var result = Change(coins, amount);
        Console.WriteLine(result);
    }
}
