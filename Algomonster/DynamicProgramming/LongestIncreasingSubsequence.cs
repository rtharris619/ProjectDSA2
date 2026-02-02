using System.Security.Cryptography.X509Certificates;

namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class LongestIncreasingSubsequence
{

    public static int LongestSubLen(List<int> nums)
    {
        int maxLength = 0;
        int n = nums.Count;
        int[] dp = new int[n + 1];
        dp[0] = 0;

        for (int i = 1; i < n + 1; i++)
        {
            int numi = nums[i - 1];
            dp[i] = dp[0] + 1;

            for (int j = 1; j < i; j++)
            {
                int numj = nums[j - 1];
                if (numj < numi)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            maxLength = Math.Max(maxLength, dp[i]);
        }

        return maxLength;
    }

    public static int LongestSubLen2(List<int> nums)
    {
        int maxLength = 0;

        var subsets = GenerateSubsets(nums);

        foreach (var subset in subsets)
        {
            if (IsIncreasing(subset))
            {
                maxLength = Math.Max(maxLength, subset.Count);
            }
        }

        return maxLength;
    }

    public static List<List<int>> GenerateSubsets(List<int> nums)
    {
        int n = nums.Count;
        var result = new List<List<int>>();
        var current = new List<int>();

        void DFS(int i)
        {
            if (i == n)
            {
                result.Add([.. current]);
                return;
            }

            // include nums[i]
            current.Add(nums[i]);
            DFS(i + 1);
            current.RemoveAt(current.Count - 1);

            // exclude nums[i]
            DFS(i + 1);
        }

        DFS(0);
        return result;
    }

    public static bool IsIncreasing(List<int> nums)
    {
        return nums.Zip(nums.Skip(1), (a, b) => b > a).All(x => x);
    }

    /// <summary>
    /// Simplest DP Solution
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LongestSubLen3(List<int> nums)
    {
        int[] dp = new int[nums.Count];
        for (int i = 0; i < nums.Count; i++)
        {
            dp[i] = 1;
        }

        for (int i = nums.Count - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (nums[j] > nums[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }

    public static void Driver()
    {
        var nums = new List<int> { 50, 3, 10, 7, 40, 80 };
        var result = LongestSubLen3(nums);
        Console.WriteLine(result);
    }
}
