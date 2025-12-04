using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;

namespace ProjectDSA2.AdventOfCode.Helpers;

public class AdventOfCodeHelper
{
    const string BASE_URL = "https://adventofcode.com";

    private static string DownloadPuzzleInput(int year, int day)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets(typeof(AdventOfCodeHelper).Assembly, optional: true)
            .Build();

        var session = config["AOC:SESSION"];
        if (string.IsNullOrWhiteSpace(session))
            throw new InvalidOperationException("Missing AOC:SESSION in user secrets. Use __Manage User Secrets__ to add it.");

        var url = $"{BASE_URL}/{year}/day/{day}/input";

        using var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ProjectDSA2", "1.0"));
        client.DefaultRequestHeaders.Add("Cookie", $"session={session}");

        return client.GetStringAsync(url).GetAwaiter().GetResult();
    }

    public static string DownloadPuzzleInputAsString(int year, int day)
    {
        return DownloadPuzzleInput(year, day);
    }

    public static List<string> DownloadPuzzleInputAsList(int year, int day)
    {
        string input = DownloadPuzzleInput(year, day);

        var split = input.Split('\n');

        if (split.Length == 0)
        {
            return new List<string>();
        }

        var result = new List<string>();
        foreach (var line in split)
        {
            if (line.Trim() != string.Empty)
            {
                result.Add(line);
            }
        }

        return result;
    }
}
