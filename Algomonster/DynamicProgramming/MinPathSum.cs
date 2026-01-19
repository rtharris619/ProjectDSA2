using System.Runtime.Serialization;

namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class MinPathSum
{

    public static int MinPath(List<List<int>> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Count;

        int[,] dp = new int[rows, cols];
        dp[0, 0] = grid[0][0];
        for (int row = 1; row < rows; row++)
        {
            dp[row, 0] = dp[row - 1, 0] + grid[row][0];
        }
        for (int col = 1; col < cols; col++)
        {
            dp[0, col] = dp[0, col - 1] + grid[0][col];
        }

        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < cols; col++)
            {
                dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + grid[row][col];
            }
        }

        return dp[rows - 1, cols - 1];
    }

    /// <summary>
    /// Space Optimised Solution
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int MinPath2(List<List<int>> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Count;
        int[] dp = new int[cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var cell = grid[row][col];
                if (row == 0 && col == 0) // first row and column.
                {
                    dp[0] = cell;
                }
                else if (row == 0) // first row, columns other than first column.
                {
                    dp[col] = dp[col - 1] + cell;
                }
                else if (col == 0) // rows other than first row.
                {
                    dp[col] = dp[col] + cell;
                }
                else // middle rows and columns.
                {
                    dp[col] = Math.Min(dp[col - 1], dp[col]) + cell;
                }
            }
        }

        return dp[^1];
    }

    public static void Driver()
    {
        var grid = new List<List<int>>
        {
            new() { 1, 3, 1 },
            new() { 1, 5, 1 },
            new() { 4, 2, 1 },
        };

        var result = MinPath2(grid);
        Console.WriteLine(result);
    }
}
