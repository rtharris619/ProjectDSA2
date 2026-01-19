namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class UniquePathsWithObstacles
{
    public static int UniquePathsIi(List<List<int>> obstacleGrid)
    {
        int n = obstacleGrid.Count;
        int m = obstacleGrid[0].Count;
        int[,] dp = new int[n, m];

        if (obstacleGrid[0][0] == 1) return 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i, j] = 0;
                }
                else if (i == 0 || j == 0)
                {
                    dp[i, j] = 1;
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
        }

        return dp[n - 1, m - 1];
    }

    public static int UniquePathsIi2(List<List<int>> obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1) return 0;

        int rows = obstacleGrid.Count;
        int cols = obstacleGrid[0].Count;

        int[] dp = new int[cols];
        dp[0] = 1;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (obstacleGrid[row][col] == 1)
                {
                    dp[col] = 0;
                }
                else if (col > 0)
                {
                    dp[col] += dp[col - 1];
                }
            }
        }

        return dp[^1];
    }

    public static void Driver()
    {
        var obstacleGrid = new List<List<int>>
        {
            new() { 0, 0, 0 },
            new() { 0, 1, 0 },
            new() { 0, 0, 0 },
        };
        var result = UniquePathsIi2(obstacleGrid);
        Console.WriteLine(result);
    }
}
