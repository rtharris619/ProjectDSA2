using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayTwo;

public class PartOne
{

    private static long Solve(string input)
    {
        long result = 0;

        string[] ranges = input.Split(",");

        foreach (string range in ranges)
        {
            string[] strNums = range.Split("-");
            string strStart = strNums[0];
            string strEnd = strNums[1];
            long start = long.Parse(strStart);
            long end = long.Parse(strEnd);

            long current = start;
            while (current <= end)
            {
                string currentStr = current.ToString();
                if (currentStr.Length % 2 == 0)
                {
                    int mid = currentStr.Length / 2;
                    string left = currentStr[..mid];
                    string right = currentStr[mid..];
                    if (left == right)
                    {
                        result += current;
                    }
                }
                current++;
            }
        }

        return result;
    }

    private static void Tests()
    {
        string input = "11-22," +
            "95-115,998-1012," +
            "1188511880-1188511890," +
            "222220-222224," +
            "1698522-1698528," +
            "446443-446449," +
            "38593856-38593862," +
            "565653-565659," +
            "824824821-824824827," +
            "2121212118-2121212124";
        long result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        string input = AdventOfCodeHelper.DownloadPuzzleInputAsString(2025, 2);
        long result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
