namespace ProjectDSA2.Algomonster.TwoPointers;

public class ContainerWithMostWater
{
    public static int MostWater(List<int> arr)
    {
        int result = 0;
        int left = 0, right = arr.Count - 1;

        while (left < right)
        {
            int area = Math.Min(arr[left], arr[right]) * (right - left);
            result = Math.Max(result, area);

            if (arr[left] < arr[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<int> arr = new List<int> { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        int res = MostWater(arr);
        Console.WriteLine(res);
    }
}
