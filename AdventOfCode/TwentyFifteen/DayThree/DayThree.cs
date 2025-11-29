using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DayThree;

public class DayThree
{
    private static void Part1(string input)
    {
        int x = 0;
        int y = 0;
        var grid = new HashSet<(int x, int y)>
        {
            (x, y)
        };

        foreach (char move in input)
        {
            if (move == '^') 
                y++;                
            
            if (move == 'v')
                y--;
            
            if (move == '>')
                x++;

            if (move == '<')
                x--;

            grid.Add((x, y));
        }

        Console.WriteLine(grid.Count);
    }

    private static void Part2(string input)
    {
        int xs = 0, ys = 0, xr = 0, yr = 0;
        var visited = new HashSet<(int x, int y)>(capacity: input.Length + 1)
        {
            (xs, ys)
        };

        for (int i = 0; i < input.Length; i++)
        {
            char move = input[i];
            if (i % 2 == 0) // Santa
            {
                if (move == '^')
                    ys++;

                if (move == 'v')
                    ys--;

                if (move == '>')
                    xs++;

                if (move == '<')
                    xs--;

                visited.Add((xs, ys));
            }
            else // Robo-Santa
            {
                if (move == '^')
                    yr++;

                if (move == 'v')
                    yr--;

                if (move == '>')
                    xr++;

                if (move == '<')
                    xr--;

                visited.Add((xr, yr));
            }
        }

        Console.WriteLine(visited.Count);
    }

    // Encode (x,y) into a single long to avoid tuple hashing/allocation overhead.
    private static long Encode(int x, int y) => ((long)x << 32) ^ (uint)y;

    private static void Part2b(string input)
    {
        int xs = 0, ys = 0, xr = 0, yr = 0;

        var visited = new HashSet<long>(capacity: input.Length + 2)
        {
            Encode(0, 0)
        };

        ReadOnlySpan<char> span = input.AsSpan();
        for (int i = 0; i < span.Length; i++)
        {
            ref int x = ref (i % 2 == 0 ? ref xs : ref xr);
            ref int y = ref (i % 2 == 0 ? ref ys : ref yr);

            switch (span[i])
            {
                case '^': y++; break;
                case 'v': y--; break;
                case '>': x++; break;
                case '<': x--; break;
            }

            visited.Add(Encode(x, y));
        }

        Console.WriteLine(visited.Count);
    }

    private static void Tests()
    {
        string input = "^>v<";
        Part1(input);
    }

    public static void Driver()
    {
        string input = AdventOfCodeHelper.DownloadPuzzleInputAsString(2015, 3);
        Part2b(input);
    }
}
