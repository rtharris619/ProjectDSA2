namespace ProjectDSA2.Algomonster.TwoPointers;

public class LeastConsecutiveCardsToMatch
{
    public static int LeastConsecutiveCards(List<int> cards)
    {
        int minCards = cards.Count + 1;
        int left = 0;
        Dictionary<int, int> window = new Dictionary<int, int>();

        for (int right = 0; right < cards.Count; right++)
        {
            window[cards[right]] = window.GetValueOrDefault(cards[right], 0) + 1;
            while (window[cards[right]] == 2)
            {
                minCards = Math.Min(minCards, right - left + 1);                
                window[cards[left]]--;
                left++;
            }
        }

        return minCards <= cards.Count ? minCards : -1;
    }

    public static int LeastConsecutiveCards2(List<int> cards)
    {
        Dictionary<int, int> window = new Dictionary<int, int>();
        int left = 0;
        int shortest = cards.Count + 1;

        for (int right = 0; right < cards.Count; ++right)
        {
            window.TryGetValue(cards[right], out var val);
            window[cards[right]] = val + 1;
            while (window[cards[right]] == 2)
            {
                shortest = Math.Min(shortest, right - left + 1);
                window[cards[left]]--;
                left++;
            }
        }

        return shortest != cards.Count + 1 ? shortest : -1;
    }

    public static void Driver()
    {
        List<int> cards = new List<int> { 3, 4, 2, 3, 4, 7 };
        int res = LeastConsecutiveCards2(cards);
        Console.WriteLine(res);
    }
}
