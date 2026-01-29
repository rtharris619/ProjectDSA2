namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class LongestCommonSubsequence
{

    public static int LCS(string word1, string word2)
    {
        return DFS(word1, word2, word1.Length, word2.Length);
    }

    public static int DFS(string s1, string s2, int i, int j)
    {
        if (i == 0 || j == 0)
            return 0;

        if (s1[i - 1] == s2[j - 1])
            return 1 + DFS(s1, s2, i - 1, j - 1);
        else
            return Math.Max(DFS(s1, s2, i - 1, j), DFS(s1, s2, i, j - 1));
    }

    public static int LCS2(string word1, string word2)
    {
        return DFSMemo(word1, word2, word1.Length, word2.Length, new Dictionary<string, int>());
    }

    public static int DFSMemo(string s1, string s2, int i, int j, Dictionary<string, int> memo)
    {
        if (i == 0 || j == 0)
            return 0;
        string key = $"{s1[i - 1]},{s2[j - 1]}";
        if (memo.TryGetValue(key, out int value))
            return value;

        int result;
        if (s1[i - 1] == s2[j - 1])
            result = 1 + DFS(s1, s2, i - 1, j - 1);
        else
            result = Math.Max(DFS(s1, s2, i - 1, j), DFS(s1, s2, i, j - 1));

        memo.Add(key, result);
        return result;
    }

    public static int LCS3(string word1, string word2)
    {
        int[,] dp = new int[word1.Length + 1, word2.Length + 1];
        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[word1.Length, word2.Length];
    }

    public static void Driver()
    {
        string word1 = "abcde";
        string word2 = "ace";

        var result = LCS3(word1, word2);
        Console.WriteLine(result);
    }
}
