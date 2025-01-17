namespace AdventOfCode2024.Tests;

public class Day11Tests
{
    public static IEnumerable<Func<(string, long[])>> GetBlinkData()
    {
        yield return () => ("0", [1]);
        yield return () => ("12", [1, 2]);
        yield return () => ("4567", [45, 67]);
        yield return () => ("1000", [10, 0]);
        yield return () => ("1", [2024]);
        yield return () => ("0 12 4567 1000 1", [1, 1, 2, 45, 67, 10, 0, 2024]);
        yield return () => ("0 1 10 99 999", [1, 2024, 1, 0, 9, 9, 2021976]);
        yield return () => ("125 17", [253000, 1, 7]);
        yield return () => ("253000 1 7", [253, 0, 2024, 14168]);
        yield return () => ("253 0 2024 14168", [512072, 1, 20, 24, 28676032]);
        yield return () => ("512072 1 20 24 28676032", [512, 72, 2024, 2, 0, 2, 4, 2867, 6032]);
        yield return () =>
            ("512 72 2024 2 0 2 4 2867 6032", [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32]);
        yield return () => ("1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32",
            [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2]);
    }

    [Test]
    [MethodDataSource(nameof(GetBlinkData))]
    public async Task Blink(string input, long[] expected)
    {
        await Assert.That(Day11.Blink(input)).IsEquivalentTo(expected);
    }

    public static IEnumerable<(string, int, long)> GetStoneCountData()
    {
        yield return ("0", 1, 1); // 1
        yield return ("0", 2, 1); // 2024
        yield return ("0", 3, 2); // 20 24
        yield return ("0", 4, 4); // 2 0 2 4
        yield return ("0", 5, 4); // 4048 1 4048 8096
        yield return ("125 17", 1, 3);
        yield return ("125 17", 2, 4);
        yield return ("125 17", 3, 5);
        yield return ("125 17", 4, 9);
        yield return ("125 17", 5, 13);
        yield return ("125 17", 6, 22);
        yield return ("125 17", 25, 55312);
        yield return (File.ReadAllText("Day11.txt"), 25, 204022);
        yield return (File.ReadAllText("Day11.txt"), 75, 241651071960597);
    }

    [Test]
    [MethodDataSource(nameof(GetStoneCountData))]
    public async Task GetStoneCount(string input, int blinkCount, long expected)
    {
        await Assert.That(Day11.GetStoneCount(input, blinkCount)).IsEqualTo(expected);
    }
}