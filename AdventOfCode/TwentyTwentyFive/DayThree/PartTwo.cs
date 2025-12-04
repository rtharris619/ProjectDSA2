using ProjectDSA2.AdventOfCode.Helpers;
using System.Diagnostics;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayThree;

public class PartTwo
{
    const int BATTERY_COUNT = 12;

    private static long RecursiveFind(string bank, int batteriesRemaining, string numberStr)
    {
        if (numberStr.Length == BATTERY_COUNT)
        {
            return long.Parse(numberStr);
        }

        int length = bank.Length;
        int left = 0;
        int right = length - batteriesRemaining;

        if (batteriesRemaining == length)
        {
            numberStr += bank;
        }
        else
        {
            var digits = new Dictionary<int, int>();
            int maxDigit = 0;
            while (left <= right)
            {
                int digit = int.Parse(bank[left].ToString());
                maxDigit = Math.Max(maxDigit, digit);

                digits.TryAdd(digit, left);
                left++;
            }
            numberStr += maxDigit.ToString();

            bank = bank.Substring(digits[maxDigit] + 1);
            batteriesRemaining--;
        }

        return RecursiveFind(bank, batteriesRemaining, numberStr);
    }

    private static long SolveRecursively(List<string> input)
    {
        var sw = new Stopwatch();
        sw.Start();

        long result = 0;

        foreach (string s in input)
        {
            string bank = s.Trim();
            if (bank == string.Empty) continue;

            string numberStr = string.Empty;
            int batteriesRemaining = BATTERY_COUNT;
            result += RecursiveFind(bank, batteriesRemaining, numberStr);
        }

        sw.Stop();
        Console.WriteLine(sw.Elapsed);

        return result;
    }

    private static long Solve(List<string> input)
    {
        var sw = new Stopwatch();
        sw.Start();

        long result = 0;
        
        foreach (string s in input)
        {
            string bank = s.Trim();
            if (bank == string.Empty) continue;
            
            string numberStr = string.Empty;
            int batteriesRemaining = BATTERY_COUNT;

            while (numberStr.Length < BATTERY_COUNT)
            {
                int length = bank.Length;
                int left = 0;
                int right = length - batteriesRemaining;

                if (batteriesRemaining == length)
                {
                    numberStr += bank;
                    break;
                }

                var digits = new Dictionary<int, int>();
                int maxDigit = 0;
                while (left <= right)
                {
                    int digit = int.Parse(bank[left].ToString());
                    maxDigit = Math.Max(maxDigit, digit);

                    if (!digits.ContainsKey(digit))
                        digits.Add(digit, left);

                    left++;
                }
                numberStr += maxDigit.ToString();

                bank = bank.Substring(digits[maxDigit] + 1);
                batteriesRemaining--;
            }
            
            result += long.Parse(numberStr);
        }

        sw.Stop();
        Console.WriteLine(sw.Elapsed);
        return result;
    }

    private static void Tests()
    {
        List<string> input = new List<string>()
        {
            "987654321111111","811111111111119", "234234234234278", "818181911112111"
        };
        //input = new List<string>()
        //{
        //    "234234234234278"
        //};
        long result = SolveRecursively(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 3);
        long result = SolveRecursively(input);
        Console.WriteLine(result);

        //Tests();
    }
}
