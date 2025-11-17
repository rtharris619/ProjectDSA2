namespace ProjectDSA2.Algomonster.Heaps;

public class MergeKSortedLists
{
    public class Element
    {
        public int val;
        public List<int> currentList;
        public int headIndex;

        public Element(int val, List<int> currentList, int headIndex)
        {
            this.val = val;
            this.currentList = currentList;
            this.headIndex = headIndex;
        }
    }

    public static List<int> Merge(List<List<int>> lists)
    {
        List<int> result = new List<int>();

        PriorityQueue<Element, int> heap = new PriorityQueue<Element, int>();

        foreach (var list in lists)
        {
            heap.Enqueue(new Element(list[0], list, 0), list[0]);
        }

        while (heap.Count > 0)
        {
            Element e = heap.Dequeue();
            result.Add(e.val);
            int headIndex = e.headIndex + 1;
            if (headIndex < e.currentList.Count)
            {
                heap.Enqueue(new Element(e.currentList[headIndex], e.currentList, headIndex), e.currentList[headIndex]);
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<List<int>> lists = new List<List<int>>()
        {
            new() { 1, 3, 5 }, new() { 2, 4, 6 }, new() { 7, 10 }
        };
        List<int> result = Merge(lists);
        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}
