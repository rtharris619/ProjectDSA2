namespace ProjectDSA2.Algomonster.Heaps;

public class MedianOfStream
{
    List<int> stream = new List<int>();

    public void AddNum(int num)
    {
        stream.Add(num);
        stream.Sort(); // O(nlogn)
    }

    public double GetMean()
    {
        double mean = 0.0;
        double sum = 0;

        foreach (int num in stream)
        {
            sum += num;
        }

        mean = sum / stream.Count;
        mean = Math.Round(mean, 1);

        return mean;
    }

    public double GetMedian() 
    {
        double median = 0.0;

        if (stream.Count % 2 == 0) // evens
            median = (stream[(stream.Count / 2)] + stream[(stream.Count / 2) - 1]) / 2.0;
        else // odds
            median = stream[stream.Count / 2];

        return median;
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
