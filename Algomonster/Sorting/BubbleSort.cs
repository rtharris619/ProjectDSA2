namespace ProjectDSA2.Algomonster.Sorting;

public class BubbleSort
{
    public static List<int> SortList(List<int> unsortedList)
    {
        int n = unsortedList.Count;

        for (int i = n - 1; i >= 0; i--)
        {
            bool swapped = false;
            for (int j = 0; j < i; j++)
            {
                if (unsortedList[j] > unsortedList[j + 1])
                {
                    int temp = unsortedList[j];
                    unsortedList[j] = unsortedList[j + 1];
                    unsortedList[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                return unsortedList;
            }
        }

        return unsortedList;
    }

    public static void Driver()
    {
        List<int> unsortedList = new List<int> { 8, 10, 1, 3, 4, 6, 9, 2, 7, 5 };
        List<int> res = SortList(unsortedList);
        Console.WriteLine(string.Join(' ', res));
    }
}
