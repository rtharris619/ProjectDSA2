namespace ProjectDSA2.Algomonster.Heaps;

public class KClosestPoints
{
    public static List<List<int>> KClosest(List<List<int>> points, int k)
    {
        PriorityQueue<int, double> heap = new PriorityQueue<int, double>();
        for (int i = 0; i < points.Count; i++)
        {
            double distance = Math.Sqrt(Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
            heap.Enqueue(i, distance);
        }

        List<List<int>> result = new List<List<int>>();
        while (k > 0 && heap.Count > 0)
        {
            var index = heap.Dequeue();
            result.Add(points[index]);
            k--;
        }

        return result;
    }

    public static void Driver()
    {
        List<List<int>> points = new List<List<int>>()
        {
            new() { 1,1 }, new() { 2,2 }, new() { 3,3 }
        };
        int k = 2;

        List<List<int>> result = KClosest(points, k);
        foreach (List<int> point in result)
        {
            Console.WriteLine($"({point[0]}, {point[1]})");
        }
    }
}
