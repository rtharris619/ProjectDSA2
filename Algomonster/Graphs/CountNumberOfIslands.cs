namespace ProjectDSA2.Algomonster.Graphs;

public class CountNumberOfIslands
{
    public static IEnumerable<(int, int)> GetNeighbors((int row, int col) node, List<List<int>> grid)
    {
        List<int> rowDelta = new List<int>() { 0, -1, 0, 1 };
        List<int> colDelta = new List<int>() { -1, 0, 1, 0 };

        for (int i = 0; i < 4; i++)
        {
            int neighborRow = node.row + rowDelta[i];
            int neighborCol = node.col + colDelta[i];
            if (0 <= neighborRow && neighborRow < grid.Count && 
                0 <= neighborCol && neighborCol < grid[0].Count &&
                grid[neighborRow][neighborCol] == 1)
            {
                yield return (neighborRow, neighborCol);
            }
        }
    }

    public static void BFS(List<List<int>> grid, (int row, int col) node, HashSet<(int, int)> visited)
    {
        Queue<(int, int)> queue = new Queue<(int, int)> ();
        queue.Enqueue(node);
        visited.Add(node);

        while (queue.Count > 0)
        {
            var dequeued = queue.Dequeue();
            foreach (var neighbor in GetNeighbors(dequeued, grid))
            {
                if (visited.Contains(neighbor)) 
                    continue;
                queue.Enqueue(neighbor);
                visited.Add(neighbor);
            }
        }
    }

    public static int CountIslands(List<List<int>> grid)
    {
        int numberOfIslands = 0;
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        for (int row = 0; row < grid.Count; row++)
        {
            for (int col = 0; col < grid[row].Count; col++)
            {
                if (!visited.Contains((row, col)) && grid[row][col] == 1)
                {
                    BFS(grid, (row, col), visited);
                    numberOfIslands++;
                }
            }
        }

        return numberOfIslands;
    }

    public static void Driver()
    {
        int[][] grid2DArray = [
            [1, 1, 1, 0, 0, 0],
            [1, 1, 1, 1, 0, 0],
            [1, 1, 1, 0, 0, 0],
            [0, 1, 0, 0, 0, 0],
            [0, 0, 0, 0, 1, 0],
            [0, 0, 0, 0, 0, 0]
        ];

        List<List<int>> grid = grid2DArray.Select(x => x.ToList()).ToList();
        int result = CountIslands(grid);
        Console.WriteLine(result);
    }
}
