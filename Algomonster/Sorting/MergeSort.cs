namespace ProjectDSA2.Algomonster.Sorting;

public class MergeSort
{
    public static List<int> SortListInterval(List<int> unsortedList, int start, int end)
    {
        if (end - start <= 1) return unsortedList.GetRange(start, end - start);

        int midpoint = (end + start) / 2;
        List<int> leftList = SortListInterval(unsortedList, start, midpoint);
        List<int> rightList = SortListInterval(unsortedList, midpoint, end);

        List<int> result = new List<int>();

        int left = 0;
        int right = 0;

        while (left < leftList.Count || right < rightList.Count)
        {
            if (left == leftList.Count)
            {
                result.Add(rightList[right]);
                right++;
            }
            else if (right == rightList.Count)
            {
                result.Add(leftList[left]);
                left++;
            }
            else if (leftList[left] <= rightList[right])
            {
                result.Add(leftList[left]);
                left++;
            }
            else
            {
                result.Add(rightList[right]);
                right++;
            }
        }

        return result;
    }

    public static List<int> SortList(List<int> unsortedList)
    {
        return SortListInterval(unsortedList, 0, unsortedList.Count);
    }

    public static void Driver()
    {
        List<int> unsortedList = new List<int> { 8, 10, 1, 3, 4, 6, 9, 2, 7, 5 };
        List<int> res = SortList(unsortedList);
        Console.WriteLine(string.Join(' ', res));
    }
}
