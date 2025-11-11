namespace ProjectDSA2.Algomonster.Graphs;

public class SlidingPuzzle
{
    private static int Serialize(List<List<int>> gameBoard)
    {
        int total = 0;

        foreach (var row in gameBoard)
        {
            foreach (var col in row)
            {
                total *= 10;
                total += col;
            }
        }

        return total;
    }

    private static List<List<int>> Deserialize(int gameState)
    {
        List<List<int>> gameBoard = new List<List<int>>() { new List<int>(), new List<int>() };

        for (int i = 1; i >= 0; i--) // 2 rows
        {
            for (int j = 2; j >= 0; j--) // 3 cols
            {
                int exponent = i * 3 + j; // 5
                int digit = Convert.ToInt32(Math.Floor(gameState / Math.Pow(10, exponent)) % 10); // 413,205 / 10^5 % 10 = 4
                gameBoard[1 - i].Add(digit);
            }
        }

        return gameBoard;
    }

    private static (int, int) GetEmptyTile(List<List<int>> position)
    {
        int row = 0;
        int col = 0;

        for (int r = 0; r < position.Count; r++)
        {
            for (int c = 0; c < position[r].Count; c++)
            {
                if (position[r][c] == 0)
                {
                    return (r, c);
                }
            }
        }

        return (row, col);
    }

    private static IEnumerable<(int row, int col)> GetNeighbors(int row, int col)
    {
        List<int> deltaRows = new List<int>()
        {
            0, -1, 0, 1
        };
        List<int> deltaCols = new List<int>()
        {
            -1, 0, 1, 0
        };

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + deltaRows[i];
            int newCol = col + deltaCols[i];

            if (newRow >= 0 && newRow < 2 && newCol >= 0 && newCol < 3)
            {
                yield return (newRow, newCol);
            }
        }
    }

    public static int NumSteps(List<List<int>> initPos)
    {
        int target = 123450;
        int initState = Serialize(initPos);

        if (initState == target)
            return 0;

        Dictionary<int, int> movesMap = new Dictionary<int, int>() { { initState, 0 } };
        Queue<int> movesQueue = new Queue<int>();
        movesQueue.Enqueue(initState);

        while (movesQueue.Count > 0)
        {
            int topState = movesQueue.Dequeue();
            List<List<int>> topPosition = Deserialize(topState);
            (int row, int col) = GetEmptyTile(topPosition);

            foreach ((int newRow, int newCol) in GetNeighbors(row, col))
            {
                var newPosition = Deserialize(topState);
                // swap
                newPosition[row][col] = topPosition[newRow][newCol];
                newPosition[newRow][newCol] = topPosition[row][col];

                var newState = Serialize(newPosition);
                if (!movesMap.ContainsKey(newState))
                {
                    movesMap[newState] = movesMap.GetValueOrDefault(topState, 0) + 1;
                    movesQueue.Enqueue(newState);
                    if (newState == target)
                        return movesMap[newState];
                }
            }
        }

        return -1;
    }

    public static void Driver()
    {
        List<List<int>> initPos = new List<List<int>>()
        {
            new List<int>() { 4, 1, 3 },
            new List<int>() { 2, 0, 5 },
        };

        int result = NumSteps(initPos);
        Console.WriteLine(result);
    }
}
