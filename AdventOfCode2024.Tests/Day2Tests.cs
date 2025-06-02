namespace AdventOfCode2024.Tests;

public class Day2Tests
{
    private static readonly string PuzzleInput = File.ReadAllText("Day2.txt");

    [Test]
    [Arguments(new[] { 1, 2 }, true)]
    [Arguments(new[] { 2, 1 }, true)]
    [Arguments(new[] { 1, 3 }, true)]
    [Arguments(new[] { 1, 4 }, true)]
    [Arguments(new[] { 1, 5 }, false)]
    [Arguments(new[] { 1, 1 }, false)]
    [Arguments(new[] { 1, 2, 3 }, true)]
    [Arguments(new[] { 1, 2, 5 }, true)]
    [Arguments(new[] { 1, 2, 6 }, false)]
    [Arguments(new[] { 6, 2, 1 }, false)]
    [Arguments(new[] { 1, 2, 4, 3 }, false)]
    [Arguments(new[] { 7, 6, 4, 2, 1 }, true)]
    [Arguments(new[] { 1, 3, 6, 7, 9 }, true)]
    [Arguments(new[] { 1, 2, 7, 8, 9 }, false)]
    [Arguments(new[] { 9, 7, 6, 2, 1 }, false)]
    [Arguments(new[] { 1, 3, 2, 4, 5 }, false)]
    [Arguments(new[] { 8, 6, 4, 4, 1 }, false)]
    public async Task IsSafe(int[] report, bool expected)
    {
        await Assert.That(Day2.IsSafe(report)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetNumberOfSafeReportsData()
    {
        yield return ("""
                      1 9
                      3 8
                      """, 0);
        yield return ("""
                      1 2
                      3 8
                      """, 1);
        yield return ("""
                      1 2
                      3 4
                      """, 2);
        yield return ("""
                      7 6 4 2 1
                      1 2 7 8 9
                      9 7 6 2 1
                      1 3 2 4 5
                      8 6 4 4 1
                      1 3 6 7 9
                      """, 2);
        yield return (PuzzleInput, 407);
    }

    [Test]
    [MethodDataSource(nameof(GetNumberOfSafeReportsData))]
    public async Task GetNumberOfSafeReports(string input, int expected)
    {
        await Assert.That(Day2.GetNumberOfSafeReports(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(new[] { 1, 1, 2 }, true)]
    [Arguments(new[] { 1, 4, 3 }, true)]
    [Arguments(new[] { 1, 5, 6 }, true)]
    [Arguments(new[] { 0, 0, 1 }, true)]
    [Arguments(new[] { 1, 0, 0 }, true)]
    [Arguments(new[] { 1, 5, 4, 7 }, true)]
    [Arguments(new[] { 7, 4, 5, 1 }, true)]
    [Arguments(new[] { 2, 1, 2, 3 }, true)]
    [Arguments(new[] { 2, 3, 2, 1 }, true)]
    [Arguments(new[] { 7, 6, 4, 2, 1 }, true)]
    [Arguments(new[] { 1, 3, 6, 7, 9 }, true)]
    [Arguments(new[] { 1, 2, 7, 8, 9 }, false)]
    [Arguments(new[] { 9, 7, 6, 2, 1 }, false)]
    [Arguments(new[] { 1, 3, 2, 4, 5 }, true)]
    [Arguments(new[] { 8, 6, 4, 4, 1 }, true)]
    public async Task IsSafeWithProblemDampener(int[] report, bool expected)
    {
        await Assert.That(Day2.IsSafe(report, useProblemDampener: true)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetNumberOfSafeReportsWithProblemDampenerData()
    {
        yield return ("""
                      1 9
                      3 8
                      """, 2);
        yield return ("""
                      1 2
                      3 8
                      """, 2);
        yield return ("""
                      1 2
                      3 4
                      """, 2);
        yield return ("""
                      7 6 4 2 1
                      1 2 7 8 9
                      9 7 6 2 1
                      1 3 2 4 5
                      8 6 4 4 1
                      1 3 6 7 9
                      """, 4);
        yield return (PuzzleInput, 459);
    }

    [Test]
    [MethodDataSource(nameof(GetNumberOfSafeReportsWithProblemDampenerData))]
    public async Task GetNumberOfSafeReportsWithProblemDampener(string input, int expected)
    {
        await Assert.That(Day2.GetNumberOfSafeReports(input, useProblemDampener: true)).IsEqualTo(expected);
    }
}