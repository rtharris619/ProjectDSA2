using ProjectDSA2.AdventOfCode.Helpers;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DayTwo;

public class DayTwo
{
    private static void Part2(List<string> input)
    {
        int total = 0;
        foreach(string line in input)
        {
            if (line.Trim() == "") continue;

            string[] items = line.Split('x');
            int length = int.Parse(items[0]);
            int width = int.Parse(items[1]);
            int height = int.Parse(items[2]);

            int presentRibbonPerimeter = Math.Min(
                (width * 2) + (height * 2), 
                Math.Min((length * 2) + (height * 2), 
                    (width * 2) + (length * 2)));

            int bowRibbonVolume = length * width * height;

            int presentRibbonTotal = presentRibbonPerimeter + bowRibbonVolume;
            total += presentRibbonTotal;
        }
        Console.WriteLine(total);
    }
        
    private static void Part1(List<string> input)
    {
        int giftsTotal = 0;
        foreach (string line in input)
        {
            if (line.Trim() == "") continue;

            string[] items = line.Split('x');
            int length = int.Parse(items[0]);
            int width = int.Parse(items[1]);
            int height = int.Parse(items[2]);

            int areaSide1 = (length * width);
            int areaSide2 = (width * height);
            int areaSide3 = (height * length);
            int surfaceArea = (2 * areaSide1) + (2 * areaSide2) + (2 * areaSide3);
            int slack = Math.Min(areaSide1, Math.Min(areaSide2, areaSide3));

            int presentTotal = surfaceArea + slack;
            giftsTotal += presentTotal;
        }
        Console.WriteLine(giftsTotal);
    }

    public static void Driver()
    {
        List<string> input = AdventOfCodeHelper.DownloadPuzzleInputAsList(2015, 2);
        Part2(input);
    }
}
