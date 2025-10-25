namespace ProjectDSA2.Algomonster.Backtracking;

public class LetterCombination
{
    public static void DFS(int n, int startIndex, string path, List<string> result)
    {
        if (startIndex == n)
        {
            result.Add(path);
            return;
        }

        foreach (char c in "ab")
        {
            path += c;
            DFS(n, startIndex + 1, path, result);
            path = path.Remove(path.Length - 1);
        }
    }

    public static List<string> Combination(int n)
    {
        var result = new List<string>();
        DFS(n, 0, "", result);
        return result;
    }

    public static void Driver()
    {
        int n = 4;
        var result = Combination(n);
        Console.WriteLine(string.Join(' ', result));
    }
}
