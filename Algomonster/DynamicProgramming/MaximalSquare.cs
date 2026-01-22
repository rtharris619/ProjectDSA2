namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class MaximalSquare
{

    public static int MaxSquare(List<List<int>> matrix)
    {
        int rows = matrix.Count;
        int cols = matrix[0].Count;
        int best = 0;
        int[,] dp = new int[rows,cols];

        for (int row = 0; row < rows; row++)
        {
            dp[row,0] = matrix[row][0];
            best = Math.Max(best, dp[row,0]);
        }

        for (int col = 0; col < cols; col++)
        {
            dp[0,col] = matrix[0][col];
            best = Math.Max(best, dp[0,col]);
        }

        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < cols; col++)
            {
                if (matrix[row][col] == 0)
                    continue;
                dp[row,col] = Math.Min(dp[row-1,col], Math.Min(dp[row,col-1], dp[row-1,col-1])) + 1;
                best = Math.Max(best, dp[row,col]);
            }
        }

        return best * best;
    }

    public static void Driver()
    {
        var matrix = new List<List<int>>
        {
            new() { 1, 0, 1, 0, 0 },
            new() { 1, 0, 1, 1, 1 },
            new() { 1, 1, 1, 1, 0 },
            new() { 1, 0, 0, 1, 0 },
        };
        var result = MaxSquare(matrix);
        Console.WriteLine(result);
    }
}
