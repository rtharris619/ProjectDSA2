using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DaySix;

public class PartOne
{

    private static long Solve(List<string> input)
    {
        long grandTotal = 0;

        var grid = ConstructGrid(input);

        for (int col = 0; col < grid[0].Count; col++)
        {
            string operation = grid[grid.Count - 1][col];
            long subTotal = 0;
            if (operation == "*")
                subTotal = 1;

            for (int row = 0; row < grid.Count - 1; row++)
            {
                if (operation == "+")
                    subTotal += long.Parse(grid[row][col]);
                else
                    subTotal *= long.Parse(grid[row][col]);
            }
            grandTotal += subTotal;
        }

        return grandTotal;
    }

    private static List<List<string>> ConstructGrid(List<string> input)
    {
        var grid = new List<List<string>>();

        foreach (var line in input)
        {
            if (line.Trim() == string.Empty) continue;
            var gridRow = new List<string>();
            string[] rowElements = line.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string row in rowElements)
            {
                gridRow.Add(row);
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
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 6);
        long result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
