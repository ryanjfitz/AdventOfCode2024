namespace AdventOfCode2024.Tests;

public class Day1Tests
{
    [Test]
    [Arguments("""
               1   3
               2   4
               """, 4)]
    [Arguments("""
               2   4
               1   3
               """, 4)]
    [Arguments("""
               3   1
               4   2
               """, 4)]
    [Arguments("""
               4   2
               3   1
               """, 4)]
    [Arguments("""
               1   4
               2   3
               """, 4)]
    [Arguments("""
               2   3
               1   4
               """, 4)]
    [Arguments("""
               3   4
               4   3
               2   5
               1   3
               3   9
               3   3
               """, 11)]
    [PuzzleInput("Day1.txt", 2378066)]
    public async Task Part1(string input, int expected)
    {
        await Assert.That(Day1.GetTotalDistance(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("""
               1   1
               2   2
               3   3
               """, 6)]
    [Arguments("""
               3   4
               4   3
               2   5
               1   3
               3   9
               3   3
               """, 31)]
    [PuzzleInput("Day1.txt", 18934359)]
    public async Task Part2(string input, int expected)
    {
        await Assert.That(Day1.GetSimilarityScore(input)).IsEqualTo(expected);
    }
}