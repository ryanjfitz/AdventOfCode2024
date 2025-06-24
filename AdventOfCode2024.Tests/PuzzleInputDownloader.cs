namespace AdventOfCode2024.Tests;

public static class PuzzleInputDownloader
{
    [Before(TestDiscovery)]
    public static async Task Download()
    {
        const string aocSessionCookie = "Put your adventofcode.com session cookie here.";

        for (int day = 1; day <= 25; day++)
        {
            if (File.Exists($"Day{day}.txt"))
            {
                continue;
            }

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Cookie", $"session={aocSessionCookie}");

            var response = await httpClient.GetAsync($"https://adventofcode.com/2024/day/{day}/input");
            response.EnsureSuccessStatusCode();

            var puzzleInput = (await response.Content.ReadAsStringAsync()).TrimEnd().ReplaceLineEndings();
            await File.WriteAllTextAsync($"Day{day}.txt", puzzleInput);
        }
    }
}