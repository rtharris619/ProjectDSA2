using ProjectDSA2.AdventOfCode.Helpers;
using System;
using System.ComponentModel;

namespace ProjectDSA2.AdventOfCode.TwentyTwentyFive.DayFour;

public class PartOne
{

    private static int PaperCount((int row, int col) cell, List<List<char>> grid)
    {
        var directions = new List<(int, int)>()
        {
            (-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1)
        };

        var paperCount = 0;
        foreach ((int row, int col) direction in directions)
        {
            int newRow = cell.row + direction.row;
            int newCol = cell.col + direction.col;

            // check if valid
            if (newRow < grid.Count && newCol < grid[0].Count
                && newRow >= 0 && newCol >= 0
                && grid[newRow][newCol] == '@')
            {
                paperCount++;
            }
        }

        return paperCount;
    }

    private static List<List<char>> ConstructGrid(List<string> input)
    {
        var grid = new List<List<char>>();
        for (int i = 0; i < input.Count; i++)
        {
            if (input[i].Trim() == string.Empty)
                continue;

            var itemList = new List<char>();
            for (int j = 0; j < input[i].Length; j++)
            {
                itemList.Add(input[i][j]);
            }
            grid.Add(itemList);
        }
        return grid;
    }

    private static int Solve(List<string> input)
    {
        int result = 0;
        var grid = ConstructGrid(input);

        for (int row = 0; row < grid.Count; row++)
        { 
            for (int col = 0; col < grid[row].Count; col++)
            {
                if (grid[row][col] == '@')
                {
                    if (PaperCount((row, col), grid) < 4)
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }

    private static void Tests()
    {        
        var input = new List<string>()
        {
            "..@@.@@@@.",
            "@@@.@.@.@@",
            "@@@@@.@.@@",
            "@.@@@@..@.",
            "@@.@@@@.@@",
            ".@@@@@@@.@",
            ".@.@.@.@@@",
            "@.@@@.@@@@",
            ".@@@@@@@@.",
            "@.@.@@@.@.",
        };
        int result = Solve(input);
        Console.WriteLine(result);
    }

    public static void Driver()
    {
        var input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2025, 4);
        int result = Solve(input);
        Console.WriteLine(result);

        //Tests();
    }
}
