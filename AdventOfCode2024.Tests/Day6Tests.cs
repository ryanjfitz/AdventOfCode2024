namespace AdventOfCode2024.Tests;

public class Day6Tests
{
    public static IEnumerable<(string, int)> GetData()
    {
        yield return ("^", 1);
        yield return ("""
                      .
                      ^
                      """, 2);
        yield return ("""
                      .
                      .
                      ^
                      """, 3);
        yield return ("""
                      #
                      .
                      .
                      ^
                      """, 3);
        yield return ("""
                      #.
                      ..
                      ..
                      ^.
                      """, 4);
        yield return ("""
                      #..
                      ...
                      ...
                      ^..
                      """, 5);
        yield return ("""
                      #..
                      ..#
                      ^..
                      ...
                      """, 5);
        yield return ("""
                      .#..
                      ...#
                      .^..
                      ....
                      ..#.
                      """, 7);
        yield return ("""
                      ..#..
                      ....#
                      ..^..
                      #....
                      ...#.
                      """, 10);
        yield return ("""
                      #.#
                      ..#
                      ^#.
                      """, 3);
        yield return ("""
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
                      """, 41);
        yield return (File.ReadAllText("Day6.txt"), 5312);
    }

    [Test]
    [MethodDataSource(nameof(GetData))]
    public async Task GetDistinctPositionCount(string input, int expected)
    {
        await Assert.That(Day6.GetDistinctPositionCount(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetInfiniteLoopData()
    {
        yield return ("^", 0);
        yield return ("""
                      .#...
                      ....#
                      .^...
                      .....
                      ...#.
                      """, 1);
        yield return ("""
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
                      """, 6);
        yield return (File.ReadAllText("Day6.txt"), 1748);
    }

    [Test]
    [MethodDataSource(nameof(GetInfiniteLoopData))]
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