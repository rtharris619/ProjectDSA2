namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class DistinctSubsequences
{

    public static int Subsequences(string s, string t)
    {
        int rows = s.Length;
        int cols = t.Length;
        int[,] dp = new int[rows + 1, cols + 1];
        for (int row = 0; row <= rows; row++)
        {
            dp[row, 0] = 1; // exactly 1 way to form an empty string.
        }
        for (int col = 1; col <= cols; col++)
        {
            dp[0, col] = 0; // can't form a non-empty string from an empty source.
        }

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                if (s[row - 1] == t[col - 1])
                {
                    dp[row, col] = dp[row - 1, col - 1] + dp[row - 1, col]; // use it + skip it
                }
                else
                {
                    dp[row, col] = dp[row - 1, col]; // can only skip
                }
            }
        }

        return dp[rows, cols];
    }

    public static int Subsequences2(string s, string t)
    {
        return DFS(s, t, 0, 0, new Dictionary<string, int>());
    }

    public static int DFS(string s, string t, int i, int j, Dictionary<string, int> memo)
    {
        if (j == t.Length) // matched all of t
        {
            return 1;
        }

        if (i == s.Length) // ran out of s before matching t
        {
            return 0;
        }

        string key = $"{i},{j}";
        if (memo.TryGetValue(key, out var value))
        {
            return value;
        }

        int result = DFS(s, t, i + 1, j, memo);

        if (s[i] == t[j])
        {
            result += DFS(s, t, i + 1, j + 1, memo);
        }

        memo.Add(key, result);
        return result;
    }

    public static void Driver()
    {
        string s = "rabbbit";
        string t = "rabbit";
        int result = Subsequences2(s, t);
        Console.WriteLine(result);
    }
}
