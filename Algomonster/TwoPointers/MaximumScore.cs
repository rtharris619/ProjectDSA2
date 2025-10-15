namespace ProjectDSA2.Algomonster.TwoPointers;

public class MaximumScore
{
    public static int Score(List<int> arr1, List<int> arr2)
    {
        int MODULO = (int)Math.Pow(10, 9) + 7;

        int result = 0;
        int pointer1 = 0;
        int pointer2 = 0;
        int n = arr1.Count;
        int m = arr2.Count;
        int part1Sum = 0;
        int part2Sum = 0;

        while (pointer1 < n || pointer2 < m)
        {
            // activate teleporter
            if (pointer1 < n && pointer2 < m && arr1[pointer1] == arr2[pointer2])
            {
                result += Math.Max(part1Sum, part2Sum) + arr1[pointer1];
                result %= MODULO;
                part1Sum = 0;
                part2Sum = 0;
                pointer1++;
                pointer2++;
                continue;
            }

            if (pointer1 == n || (pointer2 != m && arr1[pointer1] > arr2[pointer2]))
            {
                part2Sum += arr2[pointer2];
                pointer2++;
            }
            else
            {
                part1Sum += arr1[pointer1];
                pointer1++;
            }
        }

        result += Math.Max(part1Sum, part2Sum);

        return result % MODULO;
    }

    public static void Driver()
    {
        List<int> arr1 = new List<int> { 2, 4, 5, 8, 10 };
        List<int> arr2 = new List<int> { 4, 6, 8, 9 };

        int res = Score(arr1, arr2);
        Console.WriteLine(res);
    }
}
