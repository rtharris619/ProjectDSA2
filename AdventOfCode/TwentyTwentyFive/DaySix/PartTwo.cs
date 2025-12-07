using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DaySix;

public class PartTwo
{

    private static long Solve(List<string> input)
    {
        long grandTotal = 0;

        var grid = ConstructGrid(input);


        return grandTotal;
    }

    private static List<List<string>> ConstructGrid(List<string> input)
    {
        var grid = new List<List<string>>();

        foreach (var line in input)
        {
            var gridRow = new List<string>();
            string[] rowElements = line.Trim().Split(" ");

            foreach (string element in rowElements)
            {
                gridRow.Add(element);
            }
            grid.Add(gridRow);
        }

        return grid;
    }

    private static void Tests()
    {
        List<string> input = new List<string>()
        {
            "123 328  51 64 ",
            " 45 64  387 23 ",
            "  6 98  215 314",
            "*   +   *   +  "
        };
        long result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        //var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 6);
        //long result = Solve(input);
        //Console.WriteLine(result);

        Tests();
    }
}
