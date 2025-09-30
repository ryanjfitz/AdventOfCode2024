namespace AdventOfCode2024.Tests;

public static class PuzzleInputDownloader
{
    [Before(TestDiscovery)]
    public static async Task Download()
    {
        const string aocSessionCookie = ""; // Put your adventofcode.com session cookie here.

        HttpClient? httpClient = null;

        try
        {
            for (int day = 1; day <= 25; day++)
            {
                if (File.Exists($"Day{day}.txt"))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(aocSessionCookie))
                {
                    throw new Exception("adventofcode.com session cookie not set.");
                }

                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("Cookie", $"session={aocSessionCookie}");
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