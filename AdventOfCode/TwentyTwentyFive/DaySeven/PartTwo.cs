using ProjectDSA2.AdventOfCode.Helpers;
using System;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DaySeven;

public class PartTwo
{

    private static long Solve(List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;

        // Locate 'S'
        int sr = -1, sc = -1;
        for (int r = 0; r < rows; r++)
        {
            int c = grid[r].IndexOf('S');
            if (c >= 0)
            {
                sr = r;
                sc = c;
                break;
            }
        }

        // DP arrays: ways to be at each column for the current row
        long[] dpPrevious = new long[cols];
        long[] dpCurrent = new long[cols];
        dpPrevious[sc] = 1; // one way at S

        // Process each row below S
        for (int row = sr + 1; row < rows; row++)
        {
            Array.Clear(dpCurrent, 0, cols);

            for (int col = 0; col < cols; col++)
            {
                long ways = dpPrevious[col];
                if (ways == 0) 
                    continue;

                // tachyon
                if (grid[row][col] == '^')
                {
                    if (col - 1 >= 0)
                        dpCurrent[col - 1] += ways;
                    if (col + 1 < cols)
                        dpCurrent[col + 1] += ways;
                }
                else // beam
                {
                    dpCurrent[col] += ways;
                }
            }

            // swap
            (dpPrevious, dpCurrent) = (dpCurrent, dpPrevious);
        }

        // Sum of ways in the last row reached
        long total = 0;
        for (int i = 0; i < dpPrevious.Length; i++)
        {
            total += dpPrevious[i];
        }
        return total;
    }

    private static void Tests()
    {
        var input = new List<string>()
        {
            ".......S.......",
            "...............",
            ".......^.......",
            "...............",
            "......^.^......",
            "...............",
            ".....^.^.^.....",
            "...............",
            "....^.^...^....",
            "...............",
            "...^.^...^.^...",
            "...............",
            "..^...^.....^..",
            "...............",
            ".^.^.^.^.^...^.",
            "...............",
        };

        long result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 7, trim: true);
        long result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
