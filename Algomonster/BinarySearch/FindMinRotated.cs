namespace ProjectDSA2.Algomonster.BinarySearch;

public class FindMinRotated
{
    public static int FindMin(List<int> arr)
    {
        int left = 0, right = arr.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if ((mid + 1) < arr.Count && arr[mid] > arr[mid + 1])
            {
                return mid + 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return 0;
    }

    public static int FindMin2(List<int> arr)
    {
        int left = 0, right = arr.Count - 1;
        int searchIndex = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= arr[arr.Count - 1])
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
        List<int> arr = new List<int>() { 30, 40, 50, 10, 20 };
        var result = FindMin2(arr);
        Console.WriteLine(result);

        arr = new List<int>() { 3, 5, 7, 11, 13, 17, 19, 2 };
        result = FindMin2(arr);
        Console.WriteLine(result);
    }
}
