using System.Runtime.CompilerServices;

namespace ProjectDSA2.Algomonster.TwoPointers;

public class MoveZeros
{
    public static void Move(List<int> nums)
    {
        int slow = 0, fast = 0;
        while (fast < nums.Count)
        {
            if (nums[fast] > 0)
            {
                (nums[slow], nums[fast]) = (nums[fast], nums[slow]);
                slow++;
            }
            fast++;
        }
    }

    public static void Move2(List<int> nums)
    {
        int slow = 0;
        for (int fast = 0; fast < nums.Count; fast++)
        {
            if (nums[fast] > 0)
            {
                nums[slow++] = nums[fast];
            }
        }

        while (slow < nums.Count)
        {
            nums[slow++] = 0;
        }
    }

    public static void Driver()
    {
        List<int> arr = new List<int> { 1, 0, 2, 0, 0, 7 };
        Move2(arr);
        Console.WriteLine(string.Join(' ', arr.Select(x => x.ToString()).ToList()));

        arr = new List<int> { 3, 1, 0, 1, 3, 8, 9 };
        Move2(arr);
        Console.WriteLine(string.Join(' ', arr.Select(x => x.ToString()).ToList()));
    }
}
