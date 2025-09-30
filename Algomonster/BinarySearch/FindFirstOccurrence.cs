namespace ProjectDSA2.Algomonster.BinarySearch;

public class FindFirstOccurrence
{
    public static int FindFirst(List<int> arr, int target)
    {
        int left = 0;
        int right = arr.Count - 1;
        int searchIndex = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                searchIndex = mid;
                right = mid - 1;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return searchIndex;
    }

    public static void Driver()
    {
        List<int> arr = new List<int>() { 1, 3, 3, 3, 3, 6, 10, 10, 10, 100 };
        int target = 3;

        var result = FindFirst(arr, target);
        Console.WriteLine(result);

        arr = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19 };
        target = 6;

        result = FindFirst(arr, target);
        Console.WriteLine(result);
    }
}
