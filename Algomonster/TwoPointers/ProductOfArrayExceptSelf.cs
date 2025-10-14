namespace ProjectDSA2.Algomonster.TwoPointers;

public class ProductOfArrayExceptSelf
{
    public static List<int> ProductOfArray(List<int> nums)
    {
        int length = nums.Count;
        List<int> result = new List<int>(length);

        for (int i = 0; i < length; i++)
        {
            result.Add(1);
        }

        int left = 1;
        for (int i = 0; i < length; i++)
        {
            result[i] = left;
            left *= nums[i];
        }

        int right = 1;
        for (int i = length - 1; i >= 0; i--)
        {
            result[i] *= right;
            right *= nums[i];
        }

        return result;
    }

    public static void Driver()
    {
        List<int> nums = new List<int> { 1, 2, 3, 4 };
        List<int> res = ProductOfArray(nums);
        Console.WriteLine(string.Join(' ', res));
    }
}
