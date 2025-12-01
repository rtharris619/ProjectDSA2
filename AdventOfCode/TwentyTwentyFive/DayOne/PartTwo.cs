using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayOne;

public class PartTwo
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
            int prevDialPosition = dialPosition;

            if (str.StartsWith('L'))
            {
                dialPosition -= rotation;
            }
            else
            {
                dialPosition += rotation;
            }

            int rotationCount = Convert.ToInt32(Math.Floor(Math.Abs(dialPosition) / 100M));
            result += rotationCount;

            // we crossed over the 0 line from positive to negative
            if (prevDialPosition > 0 && dialPosition < 0)
                result++;

            if (dialPosition == 0)
                result++;

            // gets mathematical modulo (not trucated toward zero in standard C#)
            dialPosition = ((dialPosition % 100) + 100) % 100;
        }

        return result;
    }

    private static void Tests()
    {
        //List<string> rotations = new List<string>()
        //{
        //    "L68",
        //    "L30",
        //    "R48",
        //    "L5",
        //    "R60",
        //    "L55",
        //    "L1",
        //    "L99",
        //    "R14",
        //    "L82",
        //};

        List<string> rotations = new List<string>()
        {
            "R1000",
            "L55",
        };

        int result = Solve(rotations);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 1);
        int result = Solve(input);
        Console.WriteLine(result); // 3116 too low, 7120 too high
        //Tests();
    }
}
