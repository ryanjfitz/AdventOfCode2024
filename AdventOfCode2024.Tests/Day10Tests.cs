namespace AdventOfCode2024.Tests;

public class Day10Tests
{
    private static readonly string PuzzleInput = File.ReadAllText("Day10.txt");

    public static IEnumerable<(string, int)> GetScoreData()
    {
        yield return ("0123456789", 1);
        yield return ("9876543210", 1);
        yield return ("123456789", 0);
        yield return ("012345678", 0);
        yield return ("5678901234", 0);
        yield return ("9876543210123456789", 2);
        yield return ("""
                      0
                      1
                      2
                      3
                      4
                      5
                      6
                      7
                      8
                      9
                      """, 1);
        yield return ("""
                      9
                      8
                      7
                      6
                      5
                      4
                      3
                      2
                      1
                      0
                      """, 1);
        yield return ("""
                      0123456789
                      9876543210
                      """, 4);
        yield return ("""
                      01234
                      98765
                      """, 1);
        yield return ("""
                      01
                      32
                      45
                      76
                      89
                      """, 1);
        yield return ("""
                      ...0...
                      ...1...
                      ...2...
                      6543456
                      7.....7
                      8.....8
                      9.....9
                      """, 2);
        yield return ("""
                      ..90..9
                      ...1.98
                      ...2..7
                      6543456
                      765.987
                      876....
                      987....
                      """, 4);
        yield return ("""
                      10..9..
                      2...8..
                      3...7..
                      4567654
                      ...8..3
                      ...9..2
                      .....01
                      """, 3);
        yield return ("""
                      89010123
                      78121874
                      87430965
                      96549874
                      45678903
                      32019012
                      01329801
                      10456732
                      """, 36);
        yield return (PuzzleInput, 733);
    }

    [Test]
    [MethodDataSource(nameof(GetScoreData))]
    public async Task GetTotalTrailheadScore(string input, int expected)
    {
        await Assert.That(Day10.GetTotalTrailheadScore(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetRatingData()
    {
        yield return ("""
                      .....0.
                      ..4321.
                      ..5..2.
                      ..6543.
                      ..7..4.
                      ..8765.
                      ..9....
                      """, 3);
        yield return ("""
                      ..90..9
                      ...1.98
                      ...2..7
                      6543456
                      765.987
                      876....
                      987....
                      """, 13);
        yield return ("""
                      012345
                      123456
                      234567
                      345678
                      4.6789
                      56789.
                      """, 227);
        yield return ("""
                      89010123
                      78121874
                      87430965
                      96549874
                      45678903
                      32019012
                      01329801
                      10456732
                      """, 81);
        yield return (PuzzleInput, 1514);
    }

    [Test]
    [MethodDataSource(nameof(GetRatingData))]
    public async Task GetTotalTrailheadRating(string input, int expected)
    {
        await Assert.That(Day10.GetTotalTrailheadRating(input)).IsEqualTo(expected);
    }
}