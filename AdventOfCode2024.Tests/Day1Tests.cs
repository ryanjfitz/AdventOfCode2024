namespace AdventOfCode2024.Tests;

public class Day1Tests
{
    public static TheoryData<string, int> GetTotalDistanceData =>
        new()
        {
            {
                """
                1   3
                2   4
                """,
                4
            },
            {
                """
                2   4
                1   3
                """,
                4
            },
            {
                """
                3   1
                4   2
                """,
                4
            },
            {
                """
                4   2
                3   1
                """,
                4
            },
            {
                """
                1   4
                2   3
                """,
                4
            },
            {
                """
                2   3
                1   4
                """,
                4
            },
            {
                """
                3   4
                4   3
                2   5
                1   3
                3   9
                3   3
                """,
                11
            },
            { File.ReadAllText("Day1.txt"), 2378066 }
        };

    [Theory]
    [MemberData(nameof(GetTotalDistanceData))]
    public void Part1(string input, int expected)
    {
        Assert.Equal(expected, Day1.GetTotalDistance(input));
    }

    public static TheoryData<string, int> GetSimilarityScoreData =>
        new()
        {
            {
                """
                1   1
                2   2
                3   3
                """,
                6
            },
            {
                """
                3   4
                4   3
                2   5
                1   3
                3   9
                3   3
                """,
                31
            },
            { File.ReadAllText("Day1.txt"), 18934359 }
        };

    [Theory]
    [MemberData(nameof(GetSimilarityScoreData))]
    public void Part2(string input, int expected)
    {
        Assert.Equal(expected, Day1.GetSimilarityScore(input));
    }
}