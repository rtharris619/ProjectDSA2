using ProjectDSA2.AdventOfCode.Helpers;
using System.Diagnostics;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayFive;

public class PartTwo
{

    private static long Solve(List<string> input)
    {
        long freshIngredientCount = 0;

        List<(long start, long end)> freshIngredients = [];

        foreach (string item in input)
        {
            if (item.Trim() == string.Empty)
            {
                break;
            }

            string[] range = item.Split('-');
            long start = long.Parse(range[0]);
            long end = long.Parse(range[1]);
            freshIngredients.Add((start, end));            
        }

        // sort by start
        freshIngredients.Sort();

        // merge by ranges
        List<(long start, long end)> mergedFreshIngredients = [];
        mergedFreshIngredients.Add(freshIngredients[0]);

        for (int i = 1; i < freshIngredients.Count; i++)
        {
            var (start, end) = freshIngredients[i];
            var lastIndex = mergedFreshIngredients.Count - 1;
            var lastMerged = mergedFreshIngredients[lastIndex];

            if (lastMerged.end >= start) // merge candidate
            {
                mergedFreshIngredients[lastIndex] = (lastMerged.start, Math.Max(lastMerged.end, end));
            }
            else
            {
                mergedFreshIngredients.Add((start, end));
            }
        }

        foreach (var ingredients in mergedFreshIngredients)
        {
            freshIngredientCount += (ingredients.end - ingredients.start) + 1;
        }

        return freshIngredientCount;
    }

    private static void Tests()
    {
        List<string> input = new List<string>()
        {
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32",
        };
        long result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        var sw = new Stopwatch();
        sw.Start();
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 5);
        var result = Solve(input);
        sw.Stop();
        Console.WriteLine(sw.Elapsed);

        Console.WriteLine(result);
        //Tests();
    }
}
