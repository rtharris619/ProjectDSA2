namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class Triangle
{

    public static int MinimumTotal(List<List<int>> triangle)
    {
        int rows = triangle.Count;
        int cols = triangle[rows - 1].Count;

        int[][] dp = new int[rows][];

        for (int row = rows - 1; row >= 0; row--)
        {
            dp[row] = new int[cols];
            for (int col = 0; col < cols; col++)
            {
                if (row == rows - 1) // bottom triangle row.
                {
                    dp[row][col] = triangle[row][col];
                }
                else
                {
                    dp[row][col] = Math.Min(dp[row + 1][col], dp[row + 1][col + 1]) + triangle[row][col];
                }
            }
            cols--;
        }

        return dp[0][0];
    }

    /// <summary>
    /// Space Optimised Solution
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public static int MinimumTotal2(List<List<int>> triangle)
    {
        int rows = triangle.Count;
        int cols = triangle[rows - 1].Count;

        int[,] dp = new int[2, cols + 1];
        for (int col = 0; col <= cols; col++)
        {
            dp[0,col] = 0;
            dp[1,col] = 0;
        }

        for (int col = 0; col < cols; col++)
        {
            dp[1,col] = triangle[rows - 1][col];
        }

        for (int row = rows - 2; row >= 0; row--)
        {
            for (int col = 0; col < triangle[row].Count; col++)
            {
                dp[0,col] = Math.Min(dp[1,col], dp[1,col+1]) + triangle[row][col];
            }
            for (int col = 0; col < triangle[row].Count; col++)
            {
                dp[1,col] = dp[0,col];
            }
        }

        return dp[1, 0];
    }

    /// <summary>
    /// Brute Force Solution using Recursive Combinatorial Search / Backtracking
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public static int MinimumTotal3(List<List<int>> triangle)
    {
        return DFS(triangle, 0, 0);
    }

    public static int DFS(List<List<int>> triangle, int row, int col)
    {
        if (row == triangle.Count)
            return 0;

        int left = DFS(triangle, row + 1, col);
        int right = DFS(triangle, row + 1, col + 1);

        return triangle[row][col] + Math.Min(left, right);
    }

    /// <summary>
    /// Brute Force Solution using Recursive Combinatorial Search / Backtracking and Memoization
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public static int MinimumTotal4(List<List<int>> triangle)
    {
        int[,] memo = new int[triangle.Count + 1, triangle.Count + 1];
        for (int row = 0; row <= triangle.Count; row++)
        {
            for (int col = 0; col <= triangle.Count; col++)
            {
                memo[row, col] = int.MaxValue;
            }
        }
        return DFSMemo(triangle, 0, 0, memo);
    }

    public static int DFSMemo(List<List<int>> triangle, int row, int col, int[,] memo)
    {
        if (row == triangle.Count)
            return 0;
        if (memo[row, col] != int.MaxValue)
            return memo[row, col];
        int left = DFSMemo(triangle, row + 1, col, memo);
        int right = DFSMemo(triangle, row + 1, col + 1, memo);
        memo[row, col] = Math.Min(left, right) + triangle[row][col];
        return memo[row, col];
    }

    public static void Driver()
    {
        var triangle = new List<List<int>>
        {
            new()    { 2 },
            new()   { 3,4 },
            new()  { 6,5,7 },
            new() { 4,1,3,8 },
        };
        var result = MinimumTotal4(triangle);
        Console.WriteLine(result);
    }
}
