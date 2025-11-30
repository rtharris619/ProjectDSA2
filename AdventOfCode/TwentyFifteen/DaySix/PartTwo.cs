using ProjectDSA2.AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DaySix;

public class PartTwo
{

    private static void Solve(List<string> input)
    {
        var sw = new Stopwatch();
        sw.Start();
        var grid = InitializeGrid();

        foreach (string instruction in input)
        {
            string instr = instruction.Trim();
            if (instr.StartsWith("turn on"))
            {
                string[] split = instr.Split(' ');
                string coordPair1 = split[2];
                string coordPair2 = split[4];

                string[] starting = coordPair1.Split(',');
                var start = (Convert.ToInt32(starting[0]), Convert.ToInt32(starting[1]));

                string[] ending = coordPair2.Split(',');
                var end = (Convert.ToInt32(ending[0]), Convert.ToInt32(ending[1]));

                TurnOn(grid, start, end);
            }

            if (instr.StartsWith("turn off"))
            {
                string[] split = instr.Split(' ');
                string coordPair1 = split[2];
                string coordPair2 = split[4];

                string[] starting = coordPair1.Split(',');
                var start = (Convert.ToInt32(starting[0]), Convert.ToInt32(starting[1]));

                string[] ending = coordPair2.Split(',');
                var end = (Convert.ToInt32(ending[0]), Convert.ToInt32(ending[1]));

                TurnOff(grid, start, end);
            }

            if (instr.StartsWith("toggle"))
            {
                string[] split = instr.Split(' ');
                string coordPair1 = split[1];
                string coordPair2 = split[3];

                string[] starting = coordPair1.Split(',');
                var start = (Convert.ToInt32(starting[0]), Convert.ToInt32(starting[1]));

                string[] ending = coordPair2.Split(',');
                var end = (Convert.ToInt32(ending[0]), Convert.ToInt32(ending[1]));

                Toggle(grid, start, end);
            }
        }

        int result = CountLitLights(grid);
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
        Console.WriteLine(result);
    }

    private static void TurnOn(int[,] grid, (int x, int y) starting, (int x, int y) ending)
    {
        for (int i = starting.x; i <= ending.x; i++)
        {
            for (int j = starting.y; j <= ending.y; j++)
            {
                grid[i, j] += 1;
            }
        }
    }

    private static void TurnOff(int[,] grid, (int x, int y) starting, (int x, int y) ending)
    {
        for (int i = starting.x; i <= ending.x; i++)
        {
            for (int j = starting.y; j <= ending.y; j++)
            {
                if (grid[i, j] > 0)
                    grid[i, j] -= 1;
            }
        }
    }

    private static void Toggle(int[,] grid, (int x, int y) starting, (int x, int y) ending)
    {
        for (int i = starting.x; i <= ending.x; i++)
        {
            for (int j = starting.y; j <= ending.y; j++)
            {
                grid[i, j] += 2;
            }
        }
    }

    private static int CountLitLights(int[,] grid)
    {
        int result = 0;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                result += grid[i, j];
            }
        }

        return result;
    }

    private static int[,] InitializeGrid()
    {
        int[,] grid = new int[1000, 1000];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = 0;
            }
        }

        return grid;
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2015, 6);
        Solve(input);
    }
}
