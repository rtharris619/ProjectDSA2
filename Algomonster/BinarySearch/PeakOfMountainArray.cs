namespace ProjectDSA2.Algomonster.BinarySearch;

public class PeakOfMountainArray
{
    public static int MountainPeak(List<int> arr)
    {
        int left = 0, right = arr.Count - 1;
        int peakIndex = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] > arr[mid + 1])
            {
                peakIndex = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return peakIndex;
    }

    public static void Driver()
    {
        List<int> arr = new List<int>() { 0, 1, 2, 3, 2, 1, 0 };
        var result = MountainPeak(arr);
        Console.WriteLine(result);

        arr = new List<int>() { 0, 10, 3, 2, 1, 0 };
        result = MountainPeak(arr);
        Console.WriteLine(result);
    }
}
