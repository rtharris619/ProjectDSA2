namespace ProjectDSA2.Algomonster.TwoPointers;

public class SubarraySumShortest
{
    public static int SumShortest(List<int> nums, int target)
    {
        int shortest = nums.Count;
        int left = 0;
        int window = 0;

        for (int right = 0; right < nums.Count; right++)
        {
            window += nums[right];
            while (window >= target)
            {
                shortest = Math.Min(shortest, right - left + 1);
                window -= nums[left];
                left++;
            }
        }

        return shortest;
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, 4, 1, 7, 3, 0, 2, 5 };
        int target = 10;
        int res = SumShortest(nums, target);
        Console.WriteLine(res);
    }
}
