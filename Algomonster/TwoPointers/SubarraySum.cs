namespace ProjectDSA2.Algomonster.TwoPointers;

public class SubarraySum
{
    public static List<int> Sum(List<int> arr, int target)
    {
        Dictionary<int, int> prefixSums = new Dictionary<int, int>();
        prefixSums[0] = 0;
        int currentSum = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            currentSum += arr[i];
            int complement = currentSum - target;
            if (prefixSums.ContainsKey(complement))
            {
                return [prefixSums[complement], i + 1];
            }

            prefixSums[currentSum] = prefixSums.GetValueOrDefault(currentSum, i + 1);
        }

        return [];
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, -20, -3, 30, 5, 4 };
        int target = 7;
        List<int> res = Sum(nums, target);
        Console.WriteLine(string.Join(' ', res));

        nums = new List<int> { 1, 3, -3, 8, 5, 7 };
        target = 5;
        res = Sum(nums, target);
        Console.WriteLine(string.Join(' ', res));
    }
}
