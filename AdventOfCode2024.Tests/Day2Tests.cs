namespace AdventOfCode2024.Tests;

public class Day2Tests
{
    [Theory]
    [InlineData(new[] { 1, 2 }, true)]
    [InlineData(new[] { 2, 1 }, true)]
    [InlineData(new[] { 1, 3 }, true)]
    [InlineData(new[] { 1, 4 }, true)]
    [InlineData(new[] { 1, 5 }, false)]
    [InlineData(new[] { 1, 1 }, false)]
    [InlineData(new[] { 1, 2, 3 }, true)]
    [InlineData(new[] { 1, 2, 5 }, true)]
    [InlineData(new[] { 1, 2, 6 }, false)]
    [InlineData(new[] { 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 2, 4, 3 }, false)]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, false)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, false)]
    public void IsSafe(int[] report, bool expected)
    {
        bool actual = Day2.IsSafe(report);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, int> GetNumberOfSafeReportsData =>
        new()
        {
            {
                """
                1 9
                3 8
                """,
                0
            },
            {
                """
                1 2
                3 8
                """,
                1
            },
            {
                """
                1 2
                3 4
                """,
                2
            },
            {
                """
                7 6 4 2 1
                1 2 7 8 9
                9 7 6 2 1
                1 3 2 4 5
                8 6 4 4 1
                1 3 6 7 9
                """,
                2
            },
            { File.ReadAllText("Day2.txt"), 407 }
        };

    [Theory]
    [MemberData(nameof(GetNumberOfSafeReportsData))]
    public void GetNumberOfSafeReports(string input, int expected)
    {
        int actual = Day2.GetNumberOfSafeReports(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 1, 2 }, true)]
    [InlineData(new[] { 1, 4, 3 }, true)]
    [InlineData(new[] { 1, 5, 6 }, true)]
    [InlineData(new[] { 0, 0, 1 }, true)]
    [InlineData(new[] { 1, 0, 0 }, true)]
    [InlineData(new[] { 1, 5, 4, 7 }, true)]
    [InlineData(new[] { 7, 4, 5, 1 }, true)]
    [InlineData(new[] { 2, 1, 2, 3 }, true)]
    [InlineData(new[] { 2, 3, 2, 1 }, true)]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, true)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, true)]
    public void IsSafeWithProblemDampener(int[] report, bool expected)
    {
        bool actual = Day2.IsSafe(report, useProblemDampener: true);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, int> GetNumberOfSafeReportsWithProblemDampenerData =>
        new()
        {
            {
                """
                1 9
                3 8
                """,
                2
            },
            {
                """
                1 2
                3 8
                """,
                2
            },
            {
                """
                1 2
                3 4
                """,
                2
            },
            {
                """
                7 6 4 2 1
                1 2 7 8 9
                9 7 6 2 1
                1 3 2 4 5
                8 6 4 4 1
                1 3 6 7 9
                """,
                4
            },
            { File.ReadAllText("Day2.txt"), 459 }
        };

    [Theory]
    [MemberData(nameof(GetNumberOfSafeReportsWithProblemDampenerData))]
    public void GetNumberOfSafeReportsWithProblemDampener(string input, int expected)
    {
        int actual = Day2.GetNumberOfSafeReports(input, useProblemDampener: true);

        Assert.Equal(expected, actual);
    }
}