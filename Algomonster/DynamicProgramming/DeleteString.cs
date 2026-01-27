namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class DeleteString
{

    public static int Delete(List<int> costs, string s1, string s2)
    {
        int rows = s1.Length;
        int cols = s2.Length;
        int[,] dp = new int[rows + 1, cols + 1];
        dp[0, 0] = 0;

        for (int row = 1; row <= rows; row++)
        {
            dp[row, 0] = dp[row - 1, 0] + costs[Cost(s1[row - 1])];
        }
        for (int col = 1; col <= cols; col++)
        {
            dp[0, col] = dp[0, col - 1] + costs[Cost(s2[col - 1])];
        }

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                if (s1[row - 1] == s2[col - 1])
                {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else
                {
                    dp[row, col] = Math.Min(dp[row - 1, col] + costs[Cost(s1[row - 1])], dp[row, col - 1] + costs[Cost(s2[col - 1])]);
                }
            }
        }
        
        return dp[rows, cols];
    }

    public static int Delete2(List<int> costs, string s1, string s2)
    {
        return DFSMemo(costs, s1, s2, 0, 0, new Dictionary<string, int>());
    }

    public static int DFSMemo(List<int> costs, string s1, string s2, int i, int j, Dictionary<string, int> memo)
    {
        if (i == s1.Length)
        {
            int cost = 0;
            for (int k = j; k < s2.Length; k++)
            {
                cost += costs[Cost(s2[k])];
            }
            return cost;
        }

        if (j == s2.Length)
        {
            int cost = 0;
            for (int k = i; k < s1.Length; k++)
            {
                cost += costs[Cost(s1[k])];
            }
            return cost;
        }

        string key = $"{i},{j}";
        if (memo.TryGetValue(key, out int value))
            return value;

        int result;
        if (s1[i] == s2[j])
        {
            result = DFSMemo(costs, s1, s2, i + 1, j + 1, memo);
        }
        else
        {
            int deleteS1 = costs[Cost(s1[i])] + DFSMemo(costs, s1, s2, i + 1, j, memo);
            int deleteS2 = costs[Cost(s2[j])] + DFSMemo(costs, s1, s2, i, j + 1, memo);
            result = Math.Min(deleteS1, deleteS2);
        }

        memo.Add(key, result);
        return result;
    }

    public static int Cost(char c)
    {
        return c - 97;
    }

    public static void Driver()
    {
        var costs = new List<int>
        {
            1, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        string s1 = "abb";
        string s2 = "bba";
        var result = Delete2(costs, s1, s2);
        Console.WriteLine(result);
    }
}
