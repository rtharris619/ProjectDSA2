namespace ProjectDSA2.Algomonster.TwoPointers;

public class FindAllAnagrams
{
    public static List<int> FindAll(string original, string check)
    {
        List<int> result = new List<int>();

        int originalLength = original.Length;
        int checkLength = check.Length;

        if (originalLength < checkLength)
            return result;

        int[] checkCounter = new int[26];
        int[] window = new int[26];

        for (int i = 0; i < checkLength; i++)
        {
            checkCounter[check[i] - 'a']++;
            window[original[i] - 'a']++;
        }

        if (checkCounter.SequenceEqual(window))
        {
            result.Add(0);
        }

        for (int R = checkLength; R < originalLength; R++)
        {
            int L = R - checkLength;
            window[original[L] - 'a']--;
            window[original[R] - 'a']++;
            if (checkCounter.SequenceEqual(window))
            {
                result.Add(L + 1);
            }
        }

        return result;
    }

    public static void Driver()
    {
        var original = "cbaebabacd";
        var check = "abc";
        List<int> res = FindAll(original, check);
        Console.WriteLine(string.Join(' ', res.Select(x => x.ToString())));

        original = "abab";
        check = "ab";
        res = FindAll(original, check);
        Console.WriteLine(string.Join(' ', res.Select(x => x.ToString())));
    }
}
