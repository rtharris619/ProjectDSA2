namespace ProjectDSA2.Algomonster.TwoPointers;

public class RemoveDuplicates
{
    public static int Remove(List<int> arr)
    {
        int low = 0, high = 0;

        while (high < arr.Count)
        {
            if (arr[high] > arr[low])
            {
                low++;
                arr[low] = arr[high];
            }
            else
            {
                high++;
            }
        }

        return low + 1;
    }

    public static int Remove2(List<int> arr)
    {
        int slow = 0;

        for (int fast = 0; fast < arr.Count; fast++)
        {
            if (arr[fast] > arr[slow])
            {
                slow++;
                arr[slow] = arr[fast];
            }
        }

        return slow + 1;
    }

    public static void Driver()
    {
        List<int> arr = new List<int> { 0, 0, 1, 1, 1, 2, 2 };
        int res = Remove2(arr);
        Console.WriteLine(res);
    }
}
