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

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://adventofcode.com/2024/day/{day}/input");
            request.Headers.Add("Cookie", $"session={aocSessionCookie}");

            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.SendAsync(request);
            httpResponseMessage.EnsureSuccessStatusCode();
            var puzzleInput = (await httpResponseMessage.Content.ReadAsStringAsync()).TrimEnd().ReplaceLineEndings();
            await File.WriteAllTextAsync($"Day{day}.txt", puzzleInput);
        }
    }
}