namespace AdventOfCode2024.Tests;

public static class PuzzleInputDownloader
{
    [Before(TestDiscovery)]
    public static async Task Download()
    {
        var aocSession = Environment.GetEnvironmentVariable("AOC_SESSION");

        HttpClient? httpClient = null;

        try
        {
            for (int day = 1; day <= 25; day++)
            {
                if (File.Exists($"Day{day}.txt"))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(aocSession))
                {
                    throw new Exception("adventofcode.com puzzle inputs cannot be downloaded due to missing session.");
                }

                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("Cookie", $"session={aocSession}");
                }

                var response = await httpClient.GetAsync($"https://adventofcode.com/2024/day/{day}/input");
                response.EnsureSuccessStatusCode();

                var puzzleInput = (await response.Content.ReadAsStringAsync()).TrimEnd().ReplaceLineEndings();
                await File.WriteAllTextAsync($"Day{day}.txt", puzzleInput);
            }
        }
        finally
        {
            httpClient?.Dispose();
        }
    }
}