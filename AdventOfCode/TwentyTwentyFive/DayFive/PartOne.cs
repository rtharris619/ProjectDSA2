using ProjectDSA2.AdventOfCode.Helpers;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayFive;

public class PartOne
{
    private static int Solve(List<string> input)
    {        
        int freshIngredientCount = 0;

        HashSet<(long start, long end)> freshIngredients = [];
        List<long> availableIngredients = [];

        bool ingredientToggle = false;
        foreach (string item in input)
        {
            if (item.Trim() == string.Empty)
            {
                ingredientToggle = true;
                continue;
            }

            if (ingredientToggle)
            {
                long ingredient = long.Parse(item);
                availableIngredients.Add(ingredient);
            }
            else
            {
                string[] range = item.Split('-');
                long start = long.Parse(range[0]);
                long end = long.Parse(range[1]);
                freshIngredients.Add((start, end));
            }
        }

        foreach (var ingredient in availableIngredients)
        {
            if (freshIngredients.Any(x => x.start <= ingredient && x.end >= ingredient))
            {
                freshIngredientCount++;
            }
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
        int result = Solve(input);
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
