namespace ProjectDSA2.Algomonster.Sorting;

public class QuickSort
{
    public static void SortListInterval(List<int> unsortedList, int start, int end)
    {
        if (end - start <= 1) return;

        int pivot = unsortedList[end - 1];
        int startPtr = start, endPtr = end - 1;
        int temp;

        // Partitioning process
        while (startPtr < endPtr)
        {
            while (unsortedList[startPtr] < pivot && startPtr < endPtr)
            {
                startPtr++;
            }
            while (unsortedList[endPtr] >= pivot && startPtr < endPtr)
            {
                endPtr--;
            }

            if (startPtr == endPtr)
            {
                break;
            }

            // swap
            temp = unsortedList[startPtr];
            unsortedList[startPtr] = unsortedList[endPtr];
            unsortedList[endPtr] = temp;
        }

        // swap and get updated pivot
        temp = unsortedList[startPtr];
        unsortedList[startPtr] = unsortedList[end - 1];
        unsortedList[end - 1] = temp;

        // recurse on left and right side of pivot
        SortListInterval(unsortedList, start, startPtr);
        SortListInterval(unsortedList, startPtr + 1, end);
    }

    public static List<int> SortList(List<int> unsortedList)
    {
        SortListInterval(unsortedList, 0, unsortedList.Count);
        return unsortedList;
    }

    public static void Driver()
    {
        List<int> unsortedList = new List<int> { 8, 10, 1, 3, 4, 6, 9, 2, 7, 5 };
        List<int> res = SortList(unsortedList);
        Console.WriteLine(string.Join(' ', res));
    }
}
