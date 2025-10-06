namespace ProjectDSA2.Algomonster.TwoPointers;

public class SubarraySumLongest
{
    public static int Longest(List<int> nums, int target)
    {
        int maxLength = 0;
        int left = 0;
        int windowSum = 0;

        for (int right = 0; right < nums.Count; right++)
        {
            windowSum += nums[right];
            while (windowSum > target)
            {
                windowSum -= nums[left];
                left++;
            }
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, 6, 3, 1, 2, 4, 5 };
        int target = 10;
        int res = Longest(nums, target);
        Console.WriteLine(res);
    }
}
