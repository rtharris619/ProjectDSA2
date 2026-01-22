namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class DungeonGame
{

    public static int Game(List<List<int>> dungeon)
    {
        int rows = dungeon.Count;
        int cols = dungeon[0].Count;

        int[,] dp = new int[rows + 1, cols + 1];

        for (int row = rows - 1; row >= 0; row--)
        {
            for (int col = cols - 1; col >= 0; col--)
            {
                if (row == rows - 1 && col == cols - 1) // last cell (Princess)
                {
                    dp[row, col] = Math.Max(1 - dungeon[row][col], 1);
                }
                else if (row == rows - 1) // last row
                {
                    dp[row, col] = Math.Max(dp[row, col + 1] - dungeon[row][col], 1);
                }
                else if (col == cols - 1) // last col
                {
                    dp[row, col] = Math.Max(dp[row + 1, col] - dungeon[row][col], 1);
                }
                else
                {
                    dp[row, col] = Math.Max(Math.Min(dp[row, col + 1], dp[row + 1, col]) - dungeon[row][col], 1);
                }
            }
        }
        
        return dp[0,0];
    }

    public static void Driver()
    {
        var dungeon = new List<List<int>>
        {
            new() { -2,  -3,  3 },
            new() { -5, -10,  1 },
            new() { 10,  30, -5 },
        };
        var result = Game(dungeon);
        Console.WriteLine(result);
    }
}
