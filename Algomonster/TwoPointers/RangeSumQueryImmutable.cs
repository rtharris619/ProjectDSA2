namespace ProjectDSA2.Algomonster.TwoPointers;

public class RangeSumQueryImmutable
{
    public static int RangeSumQuery(List<int> nums, int left, int right)
    {
        List<int> prefix = new List<int>() { 0 };

        for (int i = 0; i < nums.Count; i++)
        {
            prefix.Add(prefix[i] + nums[i]);
        }

        return prefix[right + 1] - prefix[left];
    }

    public static int RangeSumQuery2(List<int> nums, int left, int right)
    {
        int[] prefix = new int[nums.Count + 1];

        for (int i = 0; i < nums.Count; i++)
        {
            prefix[i + 1] = prefix[i] + nums[i];
        }

        return prefix[right + 1] - prefix[left];
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, 2, 3, 4 };
        int left = 1;
        int right = 3;
        int res = RangeSumQuery2(nums, left, right);
        Console.WriteLine(res);
    }
}
