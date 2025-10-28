namespace ProjectDSA2.Algomonster.Backtracking;

public class GenerateParentheses
{
    public static void DFS(int n, List<char> path, List<string> result, int openCount, int closedCount)
    {
        if (path.Count == (2 * n))
        {
            result.Add(string.Join("", path));
            return;
        }
        if (openCount < n)
        {
            path.Add('(');
            DFS(n, path, result, openCount + 1, closedCount);
            path.RemoveAt(path.Count - 1);
        }
        if (openCount > closedCount)
        {
            path.Add(')');
            DFS(n, path, result, openCount, closedCount + 1);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static List<string> Generate(int n)
    {
        var result = new List<string>();
        DFS(n, new List<char>(), result, 0, 0);
        return result;
    }

    public static void Driver()
    {
        int n = 3;
        var result = Generate(n);
        Console.WriteLine(string.Join(' ', result));
    }
}
