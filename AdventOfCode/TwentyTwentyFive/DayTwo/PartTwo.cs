using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayTwo;

public class PartTwo
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
                if (currentStr.Length == 1)
                {
                    current++;
                    continue;
                }

                int divisibility = 1;
                while (divisibility <= currentStr.Length / 2)
                {
                    if (currentStr.Length % divisibility != 0)
                    {
                        divisibility++;
                        continue;
                    }

                    string[] partitions = new string[currentStr.Length / divisibility];
                    int partition = 0;
                    for (int i = 0; i < currentStr.Length; i += divisibility)
                    {
                        partitions[partition++] = currentStr.Substring(i, divisibility);
                    }

                    // check for equality on each partition
                    var currentPartition = partitions[0];
                    bool isValid = true;

                    for (int i = 1; i < partitions.Length; i++)
                    {
                        if (partitions[i] != currentPartition)
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        result += current;
                        break;
                    }

                    divisibility++;
                }

                current++;
            }
        }

        return result;
    }

    private static void Tests()
    {
        string input =
            "11-22," +
            "95-115," +
            "998-1012," +
            "1188511880-1188511890," +
            "222220-222224," +
            "1698522-1698528," +
            "446443-446449," +
            "38593856-38593862," +
            "565653-565659," +
            "824824821-824824827," +
            "2121212118-2121212124";

        //input = "1188511880-1188511890";

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
