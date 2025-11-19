namespace ProjectDSA2.Algomonster.Heaps;

public class ReorganizeString
{
    public static string Reorganize(string s)
    {
        int n = s.Length;
        char[] result = new char[n];

        Dictionary<char, int> characterCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (characterCount.ContainsKey(c))
                characterCount[c] += 1;
            else
                characterCount.Add(c, 1);
        }

        PriorityQueue<char, int> maxHeap = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (var entry in characterCount)
        {
            maxHeap.Enqueue(entry.Key, entry.Value);
        }

        // Return the empty string if there are too many of one character
        maxHeap.TryPeek(out char el, out int pr);
        if (pr > (n + 1) / 2)
            return "";

        // start by filling out even positions until the end
        // then it is reset to 1 to fill out odd positions
        int pointer = 0;
        while (maxHeap.Count > 0)
        {
            maxHeap.TryDequeue(out char element, out int priority);

            for (int i = 0; i < priority; i++)
            {
                result[pointer] = element;
                pointer += 2;
                if (pointer >= n)
                    pointer = 1;
            }
        }

        return new string(result);
    }

    public static void Driver()
    {
        string s = "aab"; // ababa
        string result = Reorganize(s);
        Console.WriteLine(result);
    }
}
