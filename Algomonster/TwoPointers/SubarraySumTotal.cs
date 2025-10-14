namespace ProjectDSA2.Algomonster.TwoPointers;

public class SubarraySumTotal
{
    public static int SumTotal(List<int> arr, int target)
    {
        Dictionary<int, int> prefixSums = new Dictionary<int, int>();
        prefixSums[0] = 1;
        int currentSum = 0;
        int count = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            currentSum += arr[i];
            int complement = currentSum - target;

            if (prefixSums.ContainsKey(complement))
            {
                count += prefixSums[complement];
            }

            prefixSums[currentSum] = prefixSums.GetValueOrDefault(currentSum, 0) + 1;
        }

        return count;
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, -20, -3, 30, 5, 4 };
        int target = 7;
        int res = SumTotal(nums, target);
        Console.WriteLine(res);

        nums = new List<int> { 1, 3, -3, 8, 5, 7 };
        target = 5;
        res = SumTotal(nums, target);
        Console.WriteLine(res);
    }
}
