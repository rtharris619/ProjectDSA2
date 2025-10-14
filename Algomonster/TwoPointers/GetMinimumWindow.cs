namespace ProjectDSA2.Algomonster.TwoPointers;

public class GetMinimumWindow
{
    public static string GetMinimum(string original, string check)
    {
        Dictionary<char, int> checkCount = new Dictionary<char, int>();
        Dictionary<char, int> windowCount = new Dictionary<char, int>();
        int satisfied = 0;
        int required = 0;

        foreach (char c in check)
        {
            if (checkCount.ContainsKey(c)) 
            { 
                checkCount[c]++;
            }
            else
            {
                checkCount[c] = 1;
                required++;
            }
        }

        int m = original.Length;
        int length = m + 1;
        int window = -1;
        int left = 0;

        for (int right = 0; right < m; right++)
        {
            char currentChar = original[right];

            if (checkCount.ContainsKey(currentChar))
            {
                if (!windowCount.ContainsKey(currentChar))
                {
                    windowCount[currentChar] = 0;
                }
                windowCount[currentChar]++;
                if (windowCount[currentChar] == checkCount[currentChar])
                {
                    satisfied++;
                }
            }

            while (required == satisfied)
            {
                if (right - left < length ||
                    (
                        right - left + 1 == length && 
                        original.Substring(left, right - 1 + 1).CompareTo(original.Substring(window, length)) < 0
                    ))
                {
                    window = left;
                    length = right - left + 1;
                }

                char leftChar = original[left];
                if (checkCount.ContainsKey(leftChar))
                {
                    windowCount[leftChar]--;
                    if (windowCount[leftChar] < checkCount[leftChar])
                    {
                        satisfied--;
                    }
                }

                left++;
            }
        }

        return window >= 0 ? original.Substring(window, length) : "";
    }

    public static void Driver()
    {
        string original = "cdbaebaecd";
        string check = "abc";
        string res = GetMinimum(original, check);
        Console.WriteLine(res);
    }
}
