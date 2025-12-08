using ProjectDSA2.AdventOfCode.Helpers;
using static ProjectDSA2.Algomonster.Heaps.MergeKSortedLists;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DaySix;

public class PartTwo
{

    private static long Solve(List<string> input)
    {
        long grandTotal = 0;

        var grid = ConstructGrid(input); // 4 x 15 box
        List<string> operationRow = grid[grid.Count - 1];
        operationRow = [.. operationRow.Where(x => x != " ")];
        int operationCount = operationRow.Count; // equivalent to the number count
        int currentOperation = operationCount - 1;
        long total = 0;

        for (int col = grid[0].Count - 1; col >= 0; col--) // right to left
        {            
            string numberStr = string.Empty;
            string operation = operationRow[currentOperation];

            for (int row = 0; row < grid.Count - 1; row++) // top to bottom
            {
                string item = grid[row][col];
                if (item == " ")
                {
                    continue;
                }

                numberStr += item;
            }

            if (numberStr == string.Empty) // numberStr wasn't changed so we're on to the next operation
            {
                currentOperation--;
                grandTotal += total;
                total = 0;
                continue;
            }

            if (operation == "+")
            {
                total += int.Parse(numberStr);
            }
            else
            {
                total = (total > 0) ? total * int.Parse(numberStr) : int.Parse(numberStr);
            }
        }

        if (total > 0)
            grandTotal += total;

        return grandTotal;
    }

    private static List<List<string>> ConstructGrid(List<string> input)
    {
        var grid = new List<List<string>>();

        foreach (var line in input)
        {
            if (line.Trim() == string.Empty) continue;
            var gridRow = new List<string>();

            foreach (char element in line)
            {
                gridRow.Add(element.ToString());
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
