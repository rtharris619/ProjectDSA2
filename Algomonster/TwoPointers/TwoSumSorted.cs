namespace ProjectDSA2.Algomonster.TwoPointers;

public class TwoSumSorted
{
    public static List<int> Sort(List<int> arr, int target)
    {
        List<int> result = new List<int>();

        int left = 0, right = arr.Count - 1;

        while (left < right)
        {
            int sum = arr[left] + arr[right];
            if (sum == target)
            {
                result.Add(left);
                result.Add(right);
                return result;
            }
            else if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<int> arr = new List<int> { 2, 3, 4, 5, 8, 11, 18 };
        int target = 8;
        List<int> res = Sort(arr, target);
        Console.WriteLine(string.Join(' ', res.Select(x => x)));
    }
}
