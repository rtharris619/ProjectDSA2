namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class PartitionArrayForMaximumSum
{

    public static int PartitionArray(List<int> arr, int k)
    {
        int n = arr.Count;
        int[] dp = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            int curMax = 0;
            for (int j = 1; j <= Math.Min(k, i); j++)
            {
                curMax = Math.Max(curMax, arr[i - j]);
                dp[i] = Math.Max(dp[i], dp[i - j] + curMax * j);
            }
        }

        return dp[n];
    }

    public static void Driver()
    {
        var arr = new List<int> { 1, 15, 7, 9, 2, 5 };
        var k = 3;
        var result = PartitionArray(arr, k);
        Console.WriteLine(result);
    }
}
