using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DaySeven;

public class PartOne
{

    private static int Solve(List<string> grid)
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

        int[] dpPrevious = new int[cols];
        int[] dpCurrent = new int[cols];
        Array.Fill(dpPrevious, 0);
        dpPrevious[sc] = 1;
        int splits = 0;

        for (int row = sr + 2; row < rows - 1; row++)
        {
            Array.Fill(dpCurrent, 0);
            
            for (int col = 0; col < cols - 1; col++)
            {
                // beam path
                if (grid[row][col] == '.' && dpPrevious[col] > 0)
                {
                    dpCurrent[col] = dpPrevious[col];
                }

                // tachyon encountered from beam above
                if (grid[row][col] == '^' && dpPrevious[col] > 0)
                {
                    dpCurrent[col - 1] = 1;
                    dpCurrent[col + 1] = 1;
                    splits++;
                }
            }

            (dpPrevious, dpCurrent) = (dpCurrent, dpPrevious);
        }

        return splits;
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

        int result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 7);
        int result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
