namespace ProjectDSA2.Algomonster.BinarySearch;

public class FirstNotSmaller
{
    public static int FirstNotSmallerSolution(List<int> arr, int target)
    {
        int left = 0;
        int right = arr.Count - 1;
        int searchIndex = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] >= target)
            {
                searchIndex = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return searchIndex;
    }

    public static void Driver()
    {
        List<int> arr = new List<int>() { 1, 3, 3, 5, 8, 8, 10 };
        int target = 2;

        var result = FirstNotSmallerSolution(arr, target);
        Console.WriteLine(result);
    }
}
