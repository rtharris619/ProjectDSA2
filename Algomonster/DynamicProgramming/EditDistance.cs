namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class EditDistance
{

    public static int MinDistance(string word1, string word2)
    {
        int rows = word1.Length;
        int cols = word2.Length;
        int[,] dp = new int[rows + 1, cols + 1];

        for (int row = 0; row <= rows; row++)
        {
            dp[row, 0] = row;
        }
        for (int col = 0; col <= cols; col++)
        {
            dp[0, col] = col;
        }

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                if (word1[row - 1] == word2[col - 1])
                {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else
                {
                    dp[row, col] = Math.Min(dp[row - 1, col], Math.Min(dp[row, col - 1], dp[row - 1, col - 1])) + 1;
                }
            }
        }

        return dp[rows, cols];
    }

    public static void Driver()
    {
        string word1 = "horse";
        string word2 = "ros";
        int result = MinDistance(word1, word2);
        Console.WriteLine(result);
    }
}
