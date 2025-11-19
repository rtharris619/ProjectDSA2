namespace ProjectDSA2.Algomonster.Heaps;

public class NthUglyNumber
{
    public static int UglyNumber(int n)
    {
        HashSet<int> usedNumbers = new HashSet<int>();
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        int[] primeFactors = new int[] { 2, 3, 5 };

        usedNumbers.Add(1);
        minHeap.Enqueue(1, 1);

        for (int i = 0; i < n - 1; i++)
        {
            int val = minHeap.Dequeue(); // 1, 2, 3, 4, ... 24
            foreach (int multiplier in primeFactors) // 1: 2, 3, 5 : 4, 6, 10 : 9, 15 : 8, 12, 20 : 
            {
                int newVal = val * multiplier;
                if (!usedNumbers.Contains(newVal))
                {
                    usedNumbers.Add(newVal);
                    minHeap.Enqueue(newVal, newVal);
                }
            }
        }

        return minHeap.Peek();
    }

    public static void Driver()
    {
        var result = UglyNumber(15);
        Console.WriteLine(result);
    }
}
