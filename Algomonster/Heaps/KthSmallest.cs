namespace ProjectDSA2.Algomonster.Heaps;

public class KthSmallest
{
    public static int Smallest(List<List<int>> matrix, int k)
    {
        int result = 0;
        var minHeap = new PriorityQueue<(int row, int col), int>();
        int ROWS = matrix.Count;
        int COLS = matrix[0].Count;

        // add first col of each row into the heap
        for (int i = 0; i < ROWS; i++)
        {
            minHeap.Enqueue((i, 0), matrix[i][0]); // 1, 10, 12
        }

        while (k > 0)
        {
            k--;

            (int row, int col) = minHeap.Dequeue();
            result = matrix[row][col];

            if (col < COLS - 1)
            {
                minHeap.Enqueue((row, col + 1), matrix[row][col + 1]);
            }
        }

        return result;
    }

    public static void Driver()
    {
        List<List<int>> matrix = new List<List<int>>()
        {
            new() { 1, 5, 9 },
            new() { 8, 11, 13 },
            new() { 7, 13, 15 },
        };
        int k = 8;
        int result = Smallest(matrix, k);
        Console.WriteLine(result);

        matrix = new List<List<int>>()
        {
            new() { 1, 2, 4, 7, 11 },
            new() { 3, 5, 8, 12, 16 },
            new() { 6, 9, 13, 17, 20 },
            new() { 10, 14, 18, 21, 23 },
            new() { 15, 19, 22, 24, 25 },
        };
        k = 17;
        result = Smallest(matrix, k);
        Console.WriteLine(result);
    }
}
