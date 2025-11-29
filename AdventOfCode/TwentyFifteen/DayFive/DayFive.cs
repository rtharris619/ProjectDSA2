using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DayFive;

public class DayFive
{
    private static void Part2(List<string> input)
    {
        int niceStrings = 0;

        foreach (string str in input)
        {
            if (IsNiceStringPart2(str))
                niceStrings++;
        }

        Console.WriteLine(niceStrings);
    }

    private static bool IsNiceStringPart2(string str)
    {
        bool containsPairWithGap = false;
        bool containsNonOverlappingPair = false;        

        for (int i = 0; i < str.Length - 2; i++)
        {
            if (str[i] == str[i + 2])
            {
                containsPairWithGap = true;
                break;
            }
        }

        var firstIndexOfPair = new Dictionary<string, int>();
       
        for (int i = 0; i < str.Length - 1; i++)
        {
            var pair = $"{str[i]}{str[i + 1]}";

            if (!firstIndexOfPair.TryGetValue(pair, out int firstIdx))
            {
                firstIndexOfPair[pair] = i;
            }
            else // pair in dictionary so ensure they don't share a char
            {
                if (i >= firstIdx + 2)
                {
                    containsNonOverlappingPair = true;
                    break;
                }
            }
        }

        return containsPairWithGap && containsNonOverlappingPair;
    }

    private static void Part1(List<string> input)
    {
        int niceStrings = 0;

        foreach (string str in input)
        {
            if (IsNiceStringPart1(str)) 
                niceStrings++;
        }

        Console.WriteLine(niceStrings);
    }

    private static bool IsNiceStringPart1(string str)
    {
        var naughtyStrings = new HashSet<string>()
        {
            "ab", "cd", "pq", "xy"
        };
        var vowels = new HashSet<char>()
        {
            'a', 'e', 'i', 'o', 'u'
        };

        var vowelCount = 0;
        var containsDoubleLetter = false;

        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (vowels.Contains(c))
                vowelCount++;

            if (i > 0) // 1 -> str.Length
            {
                var combo = $"{str[i - 1]}{str[i]}";
                if (naughtyStrings.Contains(combo)) // instant naughty
                    return false;
                if (str[i - 1] == str[i])
                    containsDoubleLetter = true;
            }
        }

        return containsDoubleLetter && vowelCount >= 3;
    }

    private static void Tests()
    {
        List<string> tests = new List<string>()
        {
            "aaaba",  // false
            "aaaaba", // true
        };
        Part2(tests);
    }

    public static void Driver()
    {
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2015, 5);
        Part2(input);
    }
}
