namespace ProjectDSA2.Algomonster.Heaps;

public class MedianOfStream2
{
    PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

    public void AddNum(int num)
    {
        if (minHeap.Count == 0 || num < minHeap.Peek())
        {
            maxHeap.Enqueue(num, num);
        }
        else
        {
            minHeap.Enqueue(num, num);
        }
        Balance();
    }

    public double GetMedian() 
    {
        if (maxHeap.Count == minHeap.Count)
        {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
        return maxHeap.Peek();
    }

    public void Balance()
    {
        if (maxHeap.Count < minHeap.Count)
        {
            int val = minHeap.Dequeue();
            maxHeap.Enqueue(val, val);
        }
        if (maxHeap.Count > minHeap.Count + 1)
        {
            int val = maxHeap.Dequeue();
            minHeap.Enqueue(val, val);
        }
    }

    public static void Driver()
    {
        var stream = new MedianOfStream();
        stream.AddNum(1);
        stream.AddNum(2);
        stream.AddNum(3);
        var result = stream.GetMedian();
        Console.WriteLine(result);
        stream.AddNum(4);
        result = stream.GetMedian();
        Console.WriteLine(result);
    }
}
