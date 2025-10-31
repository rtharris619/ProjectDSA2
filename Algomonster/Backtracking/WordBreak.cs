namespace ProjectDSA2.Algomonster.Backtracking;

public class WordBreak
{
    private static bool DFS(int startIndex, List<string> words, string target)
    {
        if (startIndex == target.Length) return true;

        bool result = false;
        foreach (var word in words)
        {
            if (target.Substring(startIndex).StartsWith(word))
            {
                result = result || (DFS(startIndex + word.Length, words, target));
            }
        }

        return result;
    }

    private static bool DFSMemoized(int startIndex, int[] memo, List<string> words, string target)
    {
        if (startIndex == target.Length) return true;
        if (memo[startIndex] != -1) return memo[startIndex] == 1;

        int result = 0;
        foreach (var word in words)
        {
            if (target.Substring(startIndex).StartsWith(word))
            {
                if (DFSMemoized(startIndex + word.Length, memo, words, target))
                {
                    result = 1;
                    break;
                }
            }
        }

        memo[startIndex] = result;
        return result == 1;
    }

    public static bool BreakWord(string s, List<string> words)
    {
        int[] memo = new int[s.Length];
        Array.Fill(memo, -1);
        return DFSMemoized(0, memo, words, s);
    }

    public static void Driver()
    {
        string word = "aab";
        List<string> words = new List<string>() { "a", "aa", "b" };
        var result = BreakWord(word, words);
        Console.WriteLine(result);
    }
}
