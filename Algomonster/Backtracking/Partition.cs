namespace ProjectDSA2.Algomonster.Backtracking;

public class Partition
{
    public static bool IsPalindrome(string s)
    {
        int L = 0;
        int R = s.Length - 1;

        while (L < R)
        {
            if (s[L] != s[R])
                return false;
            L++;
            R--;
        }

        return true;
    }

    public static void DFS(string s, int startIndex, List<string> partition, List<List<string>> result)
    {
        if (startIndex == s.Length)
        {
            var li = new List<string>(partition);
            result.Add(li);
        }

        for (int end = startIndex; end < s.Length; end++)
        {
            string range = s.Substring(startIndex, end + 1 - startIndex);
            if (IsPalindrome(range))
            {
                partition.Add(range);
                DFS(s, end + 1, partition, result);
                partition.RemoveAt(partition.Count - 1);
            }
        }
    }

    public static List<List<string>> PartitionString(string s)
    {
        var result = new List<List<string>>();
        DFS(s, 0, new List<string>(), result);
        return result;
    }

    public static void Driver()
    {
        string s = "aab";
        var result = PartitionString(s);
        foreach (List<string> row in result)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }
}
