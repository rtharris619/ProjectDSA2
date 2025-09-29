namespace ProjectDSA2.Algomonster.Sorting;

public class SelectionSort
{
    public static List<int> SortList(List<int> unsortedList)
    {
        int n = unsortedList.Count;

        for (int i = 0; i < n; i++)
        {
            int minIndex = i;
            for (int j = i; j < n; j++)
            {
                if (unsortedList[j] < unsortedList[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = unsortedList[i];
            unsortedList[i] = unsortedList[minIndex];
            unsortedList[minIndex] = temp;
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
