namespace ProjectDSA2.Algomonster.TwoPointers;

public class SubarraySumFixed
{
    // O(n * k) solution
    public static int SubarraySum(List<int> nums, int k)
    {
        if (k > nums.Count)
            return 0;
        int maxSum = 0;

        for (int L = 0; L < (nums.Count - k + 1); L++)
        {
            int sum = 0;
            for (int R = L; R < (L + k); R++)
            {
                sum += nums[R];
            }
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }

    // O(n) solution
    public static int SubarraySum2(List<int> nums, int k)
    {
        if (k > nums.Count)
            return 0;

        int windowSum = 0;
        for (int i = 0; i < k; i++)
        {
            windowSum += nums[i];
        }
        int maxSum = windowSum;
        for (int R = k; R < nums.Count; R++)
        {
            int L = R - k;
            windowSum -= nums[L];
            windowSum += nums[R];
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, 2, 3, 7, 4, 1 };
        int k = 3;
        int res = SubarraySum2(nums, k);
        Console.WriteLine(res);
    }
}
