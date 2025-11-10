namespace ProjectDSA2.Algomonster.Graphs;

public class NumSteps
{
    public static Dictionary<char, char> NextDigit = new Dictionary<char, char>();
    public static Dictionary<char, char> PrevDigit = new Dictionary<char, char>();

    public static void SetNextDigit()
    {
        for (int i = 0; i < 10; i++)
        {
            NextDigit.Add(i.ToString()[0], ((i + 1) % 10).ToString()[0]);
        }
    }
    public static void SetPrevDigit()
    {
        foreach (var next in NextDigit)
        {
            PrevDigit.Add(next.Value, next.Key);
        }
    }

    public static int Steps(string targetCombo, List<string> trappedCombos)
    {
        if (targetCombo == "0000")
            return 0;

        SetNextDigit();
        SetPrevDigit();

        var steps = new Dictionary<string, int>() { { "0000", 0 } };
        var queue = new Queue<string>();
        queue.Enqueue("0000");

        while (queue.Count > 0)
        {
            string top = queue.Dequeue();
            for (int i = 0; i < 4; i++) // we can branch out in 4 different directions based on wheel lock
            {
                string newCombo = top.Substring(0, i) + NextDigit[top[i]] + top.Substring(i + 1, top.Length - 1 - i); // 1000
                if (!trappedCombos.Contains(newCombo) && !steps.ContainsKey(newCombo))
                {
                    queue.Enqueue(newCombo);
                    steps.Add(newCombo, steps[top] + 1);
                    if (newCombo == targetCombo)
                        return steps[newCombo];
                }
                newCombo = top.Substring(0, i) + PrevDigit[top[i]] + top.Substring(i + 1, top.Length - 1 - i); // 9000
                if (!trappedCombos.Contains(newCombo) && !steps.ContainsKey(newCombo))
                {
                    queue.Enqueue(newCombo);
                    steps.Add(newCombo, steps[top] + 1);
                    if (newCombo == targetCombo)
                        return steps[newCombo];
                }
            }
        }

        return -1;
    }

    public static void Driver()
    {
        string targetCombo = "0202";
        List<string> trappedCombos = new List<string>()
        {
            "0201",
            "0101",
            "0102",
            "1212",
            "2002"
        };
        int result = Steps(targetCombo, trappedCombos);
        Console.WriteLine(result);
    }
}
