using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DayOne;

public class DayOne
{
    private static void Part2(string input)
    {
        int floor = 0;
        char up = '(';
        char down = ')';
        int firstBasementPosition = 0;

        // O(n) TC, O(1) SC
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == up) floor++;
            if (input[i] == down) floor--;
            if (floor == -1)
            {
                firstBasementPosition = i + 1;
                break;
            }
        }

        Console.WriteLine(firstBasementPosition);
    }

    private static void Part1(string input)
    {
        int floor = 0;
        char up = '(';
        char down = ')';

        // O(n) TC, O(1) SC
        foreach (char c in input)
        {
            if (c == up) floor++;
            if (c == down) floor--;
        }

        Console.WriteLine(floor);
    }

    public static void Driver()
    {
        var input = AdventOfCodeHelper.DownloadPuzzleInput(2015, 1);
        
        Part1(input);
        Part2(input);
    }
}
