namespace ProjectDSA2.Algomonster.TwoPointers;

public class LongestSubstringWithoutRepeatingCharacters
{
    public static int LongestSubstring(string s)
    {
        int maxLength = 0;
        int left = 0;
        int[] window = new int[26];

        for (int right = 0; right < s.Length; right++) 
        {
            window[s[right] - 'a']++;

            while (window[s[right] - 'a'] > 1)
            {
                window[s[left] - 'a']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    public static int LongestSubstring2(string s)
    {
        int longest = 0;
        int left = 0;
        Dictionary<char, int> window = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            window[s[right]] = window.GetValueOrDefault(s[right], 0) + 1;

            while (window[s[right]] > 1)
            {
                window[s[left]] -= 1;
                left++;
            }

            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }

    public static void Driver()
    {
        var input = "abccabcabcc";
        var res = LongestSubstring2(input);
        Console.WriteLine(res);

        input = "aaaabaaa";
        res = LongestSubstring2(input);
        Console.WriteLine(res);

        input = "abcdbea";
        res = LongestSubstring2(input);
        Console.WriteLine(res);
    }
}
