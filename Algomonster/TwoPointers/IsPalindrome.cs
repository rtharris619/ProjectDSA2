namespace ProjectDSA2.Algomonster.TwoPointers;

public class IsPalindrome
{
    public static bool Palindrome(string s)
    {
        s = new string(s.Where(x => char.IsLetter(x)).ToArray()).ToLower();

        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }

    public static bool Palindrome2(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    public static void Driver()
    {
        string s = "Was it a car or a cat I saw?"; // wasitacaroracatisaw
        bool res = Palindrome2(s);
        Console.WriteLine(res ? "true" : "false");

        s = "A brown fox jumping over";
        res = Palindrome2(s);
        Console.WriteLine(res ? "true" : "false");
    }
}
