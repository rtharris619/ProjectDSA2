using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ProjectDSA2.AdventOfCode.TwentyFifteen.DayFour;

public class DayFour
{
    private static void Part1(string input)
    {
        string searchString = "00000";

        using var md5 = MD5.Create();

        for (int i = 1; i <= 100_000_000; i++) // 1 to 100 million
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input + i.ToString()));
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            if (hash.StartsWith(searchString))
            {
                Console.WriteLine(hash);
                Console.WriteLine(i.ToString());
                break;
            }
        }
    }

    private static void Part2(string input)
    {
        string searchString = "000000";
        using var md5 = MD5.Create();

        var sw = Stopwatch.StartNew();
        for (int i = 1; i <= 100_000_000; i++) // 1 to 100 million
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input + i.ToString()));
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            if (hash.StartsWith(searchString))
            {
                sw.Stop();
                Console.WriteLine($"Part2 Found: i={i}, hash={hash}, elapsed={sw.Elapsed}"); // 7.9, 8.4, 7.9 seconds
                break;
            }
        }
    }

    public static void Driver()
    {
        string input = "iwrupvqb";
        Part2(input);
    }
}
