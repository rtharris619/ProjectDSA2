namespace ProjectDSA2.Algomonster.Graphs;

public class FloodFill
{
    public static IEnumerable<(int row, int col)> GetNeighbors((int, int) node, List<List<int>> image, int target)
    {
        int[][] deltas = [
            [ -1, 0, 1, 0  ],
            [  0, 1, 0, -1 ]
        ];

        for (int i = 0; i < deltas[0].Length; i++)
        {
            var row = deltas[0][i] + node.Item1;
            var col = deltas[1][i] + node.Item2;
            if (row >= 0 && row < image.Count && col >= 0 && col < image[0].Count && image[row][col] == target)
            {
                yield return (row, col);
            }
        }
    }

    public static List<List<int>> Flood(int r, int c, int replacement, List<List<int>> image)
    {
        int target = image[r][c];
        image[r][c] = replacement;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        queue.Enqueue((r, c));
        visited.Add((r, c));

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var (row, col) in GetNeighbors(node, image, target))
            {
                if (visited.Contains((row, col)))
                    continue;
                image[row][col] = replacement;
                visited.Add((row, col));
                queue.Enqueue((row, col));
            }
        }

        return image;
    }

    public static void Driver()
    {
        int[][] imageArray = [
            [0, 1, 3, 4, 1], 
            [3, 8, 8, 3, 3], 
            [6, 7, 8, 8, 3], 
            [12, 2, 8, 9, 1], 
            [12, 3, 1, 3, 2]];
        List<List<int>> image = imageArray.Select(row => row.ToList()).ToList();
        int row = 2;
        int col = 2;
        int replacement = 9;
        List<List<int>> result = Flood(row, col, replacement, image);

        foreach (var item in result)
        {
            Console.WriteLine("[" + string.Join(", ", item) + "]");
        }
    }
}
