namespace AdventOfCode2024.Tests;

public class Day1Tests
{
    private static readonly string PuzzleInput = File.ReadAllText("Day1.txt");

    public static IEnumerable<(string, int)> GetTotalDistanceData()
    {
        yield return ("""
                      1   3
                      2   4
                      """, 4);
        yield return ("""
                      2   4
                      1   3
                      """, 4);
        yield return ("""
                      3   1
                      4   2
                      """, 4);
        yield return ("""
                      4   2
                      3   1
                      """, 4);
        yield return ("""
                      1   4
                      2   3
                      """, 4);
        yield return ("""
                      2   3
                      1   4
                      """, 4);
        yield return ("""
                      3   4
                      4   3
                      2   5
                      1   3
                      3   9
                      3   3
                      """, 11);
        yield return (PuzzleInput, 2378066);
    }

    [Test]
    [MethodDataSource(nameof(GetTotalDistanceData))]
    public async Task Part1(string input, int expected)
    {
        await Assert.That(Day1.GetTotalDistance(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetSimilarityScoreData()
    {
        yield return ("""
                      1   1
                      2   2
                      3   3
                      """, 6);
        yield return ("""
                      3   4
                      4   3
                      2   5
                      1   3
                      3   9
                      3   3
                      """, 31);
        yield return (PuzzleInput, 18934359);
    }

    [Test]
    [MethodDataSource(nameof(GetSimilarityScoreData))]
    public async Task Part2(string input, int expected)
    {
        await Assert.That(Day1.GetSimilarityScore(input)).IsEqualTo(expected);
    }
}