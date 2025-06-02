namespace AdventOfCode2024.Tests;

public class Day10Tests
{
    [Test]
    [Arguments("0123456789", 1)]
    [Arguments("9876543210", 1)]
    [Arguments("123456789", 0)]
    [Arguments("012345678", 0)]
    [Arguments("5678901234", 0)]
    [Arguments("9876543210123456789", 2)]
    [Arguments("""
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
               """, 1)]
    [Arguments("""
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
               """, 1)]
    [Arguments("""
               0123456789
               9876543210
               """, 4)]
    [Arguments("""
               01234
               98765
               """, 1)]
    [Arguments("""
               01
               32
               45
               76
               89
               """, 1)]
    [Arguments("""
               ...0...
               ...1...
               ...2...
               6543456
               7.....7
               8.....8
               9.....9
               """, 2)]
    [Arguments("""
               ..90..9
               ...1.98
               ...2..7
               6543456
               765.987
               876....
               987....
               """, 4)]
    [Arguments("""
               10..9..
               2...8..
               3...7..
               4567654
               ...8..3
               ...9..2
               .....01
               """, 3)]
    [Arguments("""
               89010123
               78121874
               87430965
               96549874
               45678903
               32019012
               01329801
               10456732
               """, 36)]
    [PuzzleInput("Day10.txt", 733)]
    public async Task GetTotalTrailheadScore(string input, int expected)
    {
        await Assert.That(Day10.GetTotalTrailheadScore(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("""
               .....0.
               ..4321.
               ..5..2.
               ..6543.
               ..7..4.
               ..8765.
               ..9....
               """, 3)]
    [Arguments("""
               ..90..9
               ...1.98
               ...2..7
               6543456
               765.987
               876....
               987....
               """, 13)]
    [Arguments("""
               012345
               123456
               234567
               345678
               4.6789
               56789.
               """, 227)]
    [Arguments("""
               89010123
               78121874
               87430965
               96549874
               45678903
               32019012
               01329801
               10456732
               """, 81)]
    [PuzzleInput("Day10.txt", 1514)]
    public async Task GetTotalTrailheadRating(string input, int expected)
    {
        await Assert.That(Day10.GetTotalTrailheadRating(input)).IsEqualTo(expected);
    }
}