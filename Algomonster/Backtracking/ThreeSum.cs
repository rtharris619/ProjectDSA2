namespace ProjectDSA2.Algomonster.Backtracking;

public class ThreeSum
{
    private static List<int> TwoSum(List<int> nums, int twoTarget)
    {
        List<int> result = new List<int>();
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < nums.Count; i++)
        {
            int diff = twoTarget - nums[i];
            if (set.Contains(diff))
            {
                return new List<int> { nums[i], diff };
            }

            set.Add(nums[i]);
        }

        return result;
    }

    private static List<List<int>> Triplets(List<int> nums, int target)
    {
        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < nums.Count; i++)
        {
            List<int> tuples = TwoSum(nums, target - nums[i]);
            tuples.Insert(0, nums[i]);
            result.Add(tuples);
        }

        return result;
    }

    private static List<List<int>> TripletsSorted(List<int> nums, int target)
    {
        List<List<int>> result = new List<List<int>>();
        nums.Sort();

        for (int i = 0; i < nums.Count; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i]) continue;
            var triplet = new List<int>();
            triplet.AddRange(TwoSum(nums, target - nums[i]));
            triplet.Insert(0, nums[i]);
            result.Add(triplet);
        }

        return result;
    }

    private static List<List<int>> TripletsFinal(List<int> nums, int target)
    {
        nums.Sort();
        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < nums.Count; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            var triplet = new List<int>();

            var tuples = TwoSum(nums.GetRange(i + 1, nums.Count - i - 1), target - nums[i]);
            if (tuples.Count != 0)
            {
                triplet.Add(nums[i]);
                triplet.AddRange(tuples);
                triplet.Sort();
                result.Add(triplet);
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<int> nums = new List<int>() { 3, 1, 1, 2 };
        int target = 6;

        var result = TripletsFinal(nums, target);
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(' ', item));
        }
    }
}
