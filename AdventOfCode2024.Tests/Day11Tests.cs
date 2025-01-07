namespace AdventOfCode2024.Tests;

public class Day11Tests
{
    public static TheoryData<string, long[]> BlinkData => new()
    {
        { "0", [1] },
        { "12", [1, 2] },
        { "4567", [45, 67] },
        { "1000", [10, 0] },
        { "1", [2024] },
        { "0 12 4567 1000 1", [1, 1, 2, 45, 67, 10, 0, 2024] },
        { "0 1 10 99 999", [1, 2024, 1, 0, 9, 9, 2021976] },
        { "125 17", [253000, 1, 7] },
        { "253000 1 7", [253, 0, 2024, 14168] },
        { "253 0 2024 14168", [512072, 1, 20, 24, 28676032] },
        { "512072 1 20 24 28676032", [512, 72, 2024, 2, 0, 2, 4, 2867, 6032] },
        { "512 72 2024 2 0 2 4 2867 6032", [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32] },
        {
            "1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32",
            [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2]
        }
    };

    [Theory]
    [MemberData(nameof(BlinkData))]
    public void Blink(string input, long[] expected)
    {
        Assert.Equal(expected, Day11.Blink(input));
    }

    public static TheoryData<string, int, long> GetStoneCountData => new()
    {
        { "0", 1, 1 }, // 1
        { "0", 2, 1 }, // 2024
        { "0", 3, 2 }, // 20 24
        { "0", 4, 4 }, // 2 0 2 4
        { "0", 5, 4 }, // 4048 1 4048 8096
        { "125 17", 1, 3 },
        { "125 17", 2, 4 },
        { "125 17", 3, 5 },
        { "125 17", 4, 9 },
        { "125 17", 5, 13 },
        { "125 17", 6, 22 },
        { "125 17", 25, 55312 },
        { File.ReadAllText("Day11.txt"), 25, 204022 },
        { File.ReadAllText("Day11.txt"), 75, 241651071960597 }
    };

    [Theory]
    [MemberData(nameof(GetStoneCountData))]
    public void GetStoneCount(string input, int blinkCount, long expected)
    {
        Assert.Equal(expected, Day11.GetStoneCount(input, blinkCount));
    }
}