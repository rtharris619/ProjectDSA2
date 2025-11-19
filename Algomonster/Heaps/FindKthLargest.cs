namespace ProjectDSA2.Algomonster.Heaps;

public class FindKthLargest
{
    public static int KthLargest(List<int> nums, int k)
    {
        int result = 0;

        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < nums.Count; i++)
        {
            maxHeap.Enqueue(nums[i], nums[i]);
        }
        
        for (int i = k; i > 0; i--)
        {
            result = maxHeap.Dequeue();
        }

        return result;
    }

    public static void Driver()
    {
        List<int> nums = new List<int>() { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
        int k = 4;
        int result = KthLargest(nums, k);
        Console.WriteLine(result);
    }
}
