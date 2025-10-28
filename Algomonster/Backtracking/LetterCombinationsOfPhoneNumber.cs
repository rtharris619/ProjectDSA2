namespace ProjectDSA2.Algomonster.Backtracking;

public class LetterCombinationsOfPhoneNumber
{
    private static Dictionary<string, string> digitsMap = new Dictionary<string, string>()
    {
        { "2", "abc" },
        { "3", "def" },
        { "4", "ghi" },
        { "5", "jkl" },
        { "6", "mno" },
        { "7", "pqrs" },
        { "8", "tuv" },
        { "9", "wxyz" },
    };

    private static void DFS(string digits, string path, List<string> result)
    {
        if (path.Length == digits.Length)
        {
            result.Add(path);
            return;
        }

        char nextDigit = digits[path.Length];
        foreach (char letter in digitsMap[nextDigit.ToString()])
        {
            path += letter;
            DFS(digits, path, result);
            path = path.Remove(path.Length - 1);
        }
    }

    private static void DFS2(string digits, List<char> path, List<string> result)
    {
        if (path.Count == digits.Length)
        {
            result.Add(string.Join("", path));
            return;
        }

        char nextDigit = digits[path.Count];
        foreach (char letter in digitsMap[nextDigit.ToString()])
        {
            path.Add(letter);
            DFS2(digits, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static List<string> LetterCombinations(string digits)
    {        
        List<string> result = new List<string>();
        DFS(digits, "", result);
        return result;
    }

    public static void Driver()
    {
        string digits = "56";
        var result = LetterCombinations(digits);
        Console.WriteLine(string.Join(' ', result));
    }
}
