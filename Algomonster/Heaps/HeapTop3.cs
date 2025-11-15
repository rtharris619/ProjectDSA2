namespace ProjectDSA2.Algomonster.Heaps;

public class HeapTop3
{
    public static List<int> Top3(List<int> arr)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < arr.Count; i++)
        {
            minHeap.Enqueue(arr[i], arr[i]);
        }

        List<int> result = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            var val = minHeap.Dequeue();
            result.Add(val);
        }
        return result;
    }

    public static void Driver()
    {
        List<int> result = Top3(new List<int> { 3, 5, 2, 1, 6, 9, 7, 4 });
        Console.WriteLine(string.Join(", ", result));
    }
}
