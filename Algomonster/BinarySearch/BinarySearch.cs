namespace ProjectDSA2.Algomonster.BinarySearch;

public class BinarySearch
{
    public static int Search(List<int> arr, int target)
    {
        int leftPtr = 0, rightPtr = arr.Count - 1;

        while (leftPtr <= rightPtr) 
        {
            int midPoint = leftPtr + (rightPtr - leftPtr) / 2;
            if (arr[midPoint] == target)
            {
                return midPoint;
            }
            else if (arr[midPoint] > target)
            {
                rightPtr = midPoint - 1; // target might be on the left
            }
            else
            {
                leftPtr = midPoint + 1; // target might be on the right
            }
        }

        return -1;
    }

    public static void Driver()
    {
        List<int> arr = new List<int>() { 1, 3, 5, 7, 9, 11 };
        int target = 6;

        var result = Search(arr, target);
        Console.WriteLine(result);
    }
}
