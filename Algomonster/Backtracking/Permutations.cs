namespace ProjectDSA2.Algomonster.Backtracking;

public class Permutations
{
    public static void DFS(int startIndex, string letters, bool[] used, List<char> path, List<string> result)
    {
        if (startIndex == letters.Length)
        {
            result.Add(string.Join("", path));
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (used[i]) continue;

            path.Add(letters[i]);
            used[i] = true;
            DFS(startIndex + 1, letters, used, path, result);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }

    public static List<string> Perms(string letters)
    {
        var result = new List<string>();
        DFS(0, letters, new bool[letters.Length], new List<char>(), result);
        return result;
    }

    public static void Driver()
    {
        string s = "abc";
        var result = Perms(s);
        Console.WriteLine(string.Join(' ', result));
    }
}
