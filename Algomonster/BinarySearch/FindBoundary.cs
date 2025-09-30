namespace ProjectDSA2.Algomonster.BinarySearch;

public class FindBoundary
{
    public static int Find(List<bool> arr)
    {
        int leftPtr = 0, rightPtr = arr.Count - 1;
        int boundaryIndex = -1;

        while (leftPtr <= rightPtr)
        {
            int midPoint = leftPtr + (rightPtr - leftPtr) / 2;
            if (arr[midPoint])
            {
                boundaryIndex = midPoint;
                rightPtr = midPoint - 1;
            }
            else
            {
                leftPtr = midPoint + 1;
            }
        }

        return boundaryIndex;
    }

    public static void Driver()
    {
        List<bool> arr = new List<bool>() { false, false, true, true, true };

        var result = Find(arr);
        Console.WriteLine(result);
    }
}
