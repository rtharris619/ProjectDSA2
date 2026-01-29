using System.Text;

namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class ShortestCommonSupersequence
{

    public static string Supersequence(string str1, string str2)
    {
        int rows = str1.Length;
        int cols = str2.Length;
        int[,] dp = new int[rows + 1, cols + 1];

        // LCS algorithm
        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    dp[row, col] = 1 + dp[row - 1, col - 1];
                }
                else
                {
                    dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                }
            }
        }

        var result = new StringBuilder();
        int i = str1.Length;
        int j = str2.Length;

        while (i > 0 && j > 0)
        {
            if (str1[i - 1] == str2[j - 1])
            {
                result.Append(str1[i - 1]);
                i--;
                j--;
            }
            else if (dp[i - 1, j] > dp[i, j - 1])
            {
                result.Append(str1[i - 1]);
                i--;
            }
            else
            {
                result.Append(str2[j - 1]);
                j--;
            }
        }

        while (i > 0)
            result.Append(str1[--i]);
        while (j > 0)
            result.Append(str2[--j]);

        char[] resultArr = result.ToString().ToCharArray();
        Array.Reverse(resultArr);

        return new string(resultArr);
    }

    public static void Driver()
    {
        string str1 = "abac";
        string str2 = "cab";

        string result = Supersequence(str1, str2);
        Console.WriteLine(result);
    }
}
