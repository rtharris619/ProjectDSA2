namespace ProjectDSA2.Leetcode.Easy;

public class TwoSum
{
    public static int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hashmap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (hashmap.ContainsKey(diff))
            {
                return [hashmap[diff], i];
            }

            hashmap.Add(nums[i], i);
        }

        return [-1, -1];
    }

    public static void Driver()
    {
        int[] nums = [2, 7, 11, 15];
        int target = 9;
        var result = FindTwoSum(nums, target);
        Console.WriteLine(string.Join(", ", result));

        nums = [3, 2, 4];
        target = 6;
        result = FindTwoSum(nums, target);
        Console.WriteLine(string.Join(", ", result));
    }
}
