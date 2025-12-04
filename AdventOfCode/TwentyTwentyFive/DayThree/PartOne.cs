using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayThree;

public class PartOne
{
    private static int Solve(List<string> input)
    {
        int result = 0;

        foreach (string s in input)
        {
            string bank = s.Trim();
            if (bank == string.Empty) continue;

            int L = 0;
            int R = 1;
            int maxJoltage = 0;
            while (R < bank.Length)
            {
                int leftNumber = int.Parse(bank[L].ToString());
                int rightNumber = int.Parse(bank[R].ToString());

                maxJoltage = Math.Max(maxJoltage, int.Parse(bank[L].ToString() + bank[R].ToString()));

                if (leftNumber > rightNumber)
                {
                    R++;
                }
                else
                {
                    L = R;
                    R++;
                }
            }
            result += maxJoltage;
        }

        return result;
    }

    private static void Tests()
    {
        List<string> input = new List<string>()
        {
            "987654321111111","811111111111119", "234234234234278", "818181911112111"
        };
        int result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 3);
        int result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
