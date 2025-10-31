namespace ProjectDSA2.Algomonster.Backtracking;

public class DecodeWays
{
    private static int DFS(int startIndex, string digits)
    {
        if (startIndex == digits.Length) return 1;
        if (digits[startIndex] == '0') return 0;

        int ways = 0;

        ways += DFS(startIndex + 1, digits);

        if (startIndex + 2 <= digits.Length && int.Parse(digits.Substring(startIndex, 2)) <= 26)
            ways += DFS(startIndex + 2, digits);

        return ways;
    }

    private static int DFSMemo(int startIndex, string digits, int[] memo)
    {
        if (startIndex == digits.Length) return 1;
        if (digits[startIndex] == '0') return 0;
        if (memo[startIndex] != -1) return memo[startIndex];

        int ways = 0;

        ways += DFSMemo(startIndex + 1, digits, memo);
        if (startIndex + 2 <= digits.Length && int.Parse(digits.Substring(startIndex, 2)) <= 26)
            ways += DFSMemo(startIndex + 2, digits, memo);

        memo[startIndex] = ways;
        return ways;
    }

    public static int Decode(string digits)
    {
        int[] memo = new int[digits.Length];
        Array.Fill(memo, -1);
        return DFSMemo(0, digits, memo);
    }

    public static void Driver()
    {
        string input = "123";
        var result = Decode(input);
        Console.WriteLine(result);
    }
}
