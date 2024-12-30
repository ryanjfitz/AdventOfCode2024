namespace AdventOfCode2024.Tests;

public class Day1Tests
{
    public static TheoryData<string, int> Part1Data =>
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
    [MemberData(nameof(Part1Data))]
    public void Part1(string input, int expectedTotalDistance)
    {
        int actualTotalDistance = Day1.GetTotalDistance(input);

        Assert.Equal(expectedTotalDistance, actualTotalDistance);
    }

    public static TheoryData<string, int> Part2Data =>
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
    [MemberData(nameof(Part2Data))]
    public void Part2(string input, int expectedSimilarityScore)
    {
        int actualSimilarityScore = Day1.GetSimilarityScore(input);

        Assert.Equal(expectedSimilarityScore, actualSimilarityScore);
    }
}