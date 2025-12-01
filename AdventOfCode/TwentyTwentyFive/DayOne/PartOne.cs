using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayOne;

public class PartOne
{
    private static int Solve(List<string> input)
    {
        int result = 0;
        int dialPosition = 50;

        foreach (string str in input)
        {
            if (str.Trim() == "")
                continue;

            int rotation = int.Parse(str.Substring(1));

            if (str.StartsWith('L'))
            {
                dialPosition -= rotation;
            }
            else
            {
                dialPosition += rotation;
            }

            int digits = Math.Abs(dialPosition).ToString().Length;

            while (digits > 2) // while we have 100 or more
            {
                dialPosition %= 100;
                digits = Math.Abs(dialPosition).ToString().Length;
            }

            if (dialPosition < 0)
            {
                dialPosition += 100;
            }

            if (dialPosition == 0)
            {
                result++;
            }
        }

        return result;
    }

    private static void Tests()
    {
        List<string> rotations = new List<string>()
        {
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82",
        };

        Solve(rotations);
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 1);
        int result = Solve(input);
        Console.WriteLine(result);
    }
}
