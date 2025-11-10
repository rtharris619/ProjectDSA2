namespace ProjectDSA2.Algomonster.Graphs;

public class WordLadder
{
    private static List<string> GetNeighbors(string word, HashSet<string> dictionary)
    {
        var neighbors = new List<string>();

        foreach (var candidate in dictionary) 
        {
            if (candidate.Length != word.Length || candidate == word)
                continue;

            int diff = 0;
            for (int i = 0; i < word.Length && diff <= 1; i++)
            {
                if (word[i] != candidate[i])
                    diff++;
            }

            if (diff == 1)
                neighbors.Add(candidate);
        }

        return neighbors;
    }

    public static int Ladder(string begin, string end, List<string> wordList)
    {
        if (begin == end)
            return 0;

        if (!wordList.Contains(begin))
            return 0;

        var dictionary = new HashSet<string>(wordList);
        var steps = new Dictionary<string, int>() { { begin, 0 } };
        var queue = new Queue<string>();
        queue.Enqueue(begin);

        while (queue.Count > 0)
        {
            var top = queue.Dequeue();
            var n = begin.Length;
            for (int i = 0; i < n; i++) 
            {
                var words = GetNeighbors(top, dictionary);
                foreach (var word in words)
                {
                    if (!steps.ContainsKey(word))
                    {
                        queue.Enqueue(word);
                        steps.Add(word, steps[top] + 1);
                        if (word == end)
                        {
                            return steps[word];
                        }
                    }
                }
            }
        }

        return -1;
    }

    public static void Driver()
    {
        string begin = "COLD";
        string end = "WARM";
        List<string> wordList = new List<string>()
        {
            "COLD", "GOLD", "CORD", "SOLD", "CARD", "WARD", "WARM", "TARD"
        };
        int result = Ladder(begin, end, wordList);
        Console.WriteLine(result);
    }
}
