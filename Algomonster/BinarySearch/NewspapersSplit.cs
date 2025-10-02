namespace ProjectDSA2.Algomonster.BinarySearch;

public class NewspapersSplit
{
    public static bool Feasible(List<int> newspapersReadTimes, int numCoworkers, int limit)
    {
        int currentTime = 0, currentNumWorkers = 0;

        foreach (int readTime in newspapersReadTimes)
        {
            if (currentTime + readTime > limit)
            {
                currentTime = 0;
                currentNumWorkers++;
            }
            currentTime += readTime;
        }

        if (currentTime != 0)
        {
            currentNumWorkers++;
        }

        return currentNumWorkers <= numCoworkers;
    }

    public static int Split(List<int> newspapersReadTimes, int numCoworkers)
    {
        int low = newspapersReadTimes.Max();
        int high = newspapersReadTimes.Sum();
        int ans = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Feasible(newspapersReadTimes, numCoworkers, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;
    }

    public static void Driver()
    {
        List<int> arr = new List<int>() { 7, 2, 5, 10, 8 };
        int num = 2;
        var result = Split(arr, num);
        Console.WriteLine(result);
    }
}
