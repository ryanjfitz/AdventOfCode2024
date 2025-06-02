namespace AdventOfCode2024.Tests;

public class Day6Tests
{
    [Test]
    [Arguments("^", 1)]
    [Arguments("""
               .
               ^
               """, 2)]
    [Arguments("""
               .
               .
               ^
               """, 3)]
    [Arguments("""
               #
               .
               .
               ^
               """, 3)]
    [Arguments("""
               #.
               ..
               ..
               ^.
               """, 4)]
    [Arguments("""
               #..
               ...
               ...
               ^..
               """, 5)]
    [Arguments("""
               #..
               ..#
               ^..
               ...
               """, 5)]
    [Arguments("""
               .#..
               ...#
               .^..
               ....
               ..#.
               """, 7)]
    [Arguments("""
               ..#..
               ....#
               ..^..
               #....
               ...#.
               """, 10)]
    [Arguments("""
               #.#
               ..#
               ^#.
               """, 3)]
    [Arguments("""
               ....#.....
               .........#
               ..........
               ..#.......
               .......#..
               ..........
               .#..^.....
               ........#.
               #.........
               ......#...
               """, 41)]
    [PuzzleInput("Day6.txt", 5312)]
    public async Task GetDistinctPositionCount(string input, int expected)
    {
        await Assert.That(Day6.GetDistinctPositionCount(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("^", 0)]
    [Arguments("""
               .#...
               ....#
               .^...
               .....
               ...#.
               """, 1)]
    [Arguments("""
               ....#.....
               .........#
               ..........
               ..#.......
               .......#..
               ..........
               .#..^.....
               ........#.
               #.........
               ......#...
               """, 6)]
    [PuzzleInput("Day6.txt", 1748)]
    public async Task GetInfiniteLoopObstructionCount(string input, int expected)
    {
        await Assert.That(Day6.GetInfiniteLoopObstructionCount(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("")]
    [Arguments("^^")]
    [Arguments("""
               ^
               ^
               """)]
    public async Task ThrowsIfThereIsNotExactlyOneStartingPosition(string input)
    {
        var exception = Assert.Throws<ArgumentException>(() => Day6.GetDistinctPositionCount(input));

        await Assert.That(exception.Message).IsEqualTo("Expected exactly one starting position.");
    }
}