namespace AdventOfCode2024.Tests;

public class Day8Tests
{
    [Test]
    [Arguments("", 0)]
    [Arguments("""
               .aa
               """, 1)]
    [Arguments("""
               .AA
               """, 1)]
    [Arguments("""
               .00
               """, 1)]
    [Arguments("""
               .bb
               """, 1)]
    [Arguments("""
               .aa.
               """, 2)]
    [Arguments("""
               ..a.a..
               """, 2)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ..........
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 2)]
    [Arguments("""
               .a.a..
               """, 1)]
    [Arguments("""
               .a.a.
               """, 0)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 4)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               ..........
               ..........
               ..........
               ..........
               ..........
               """, 1)]
    [Arguments("""
               ..........
               ....a.....
               ........a.
               ..........
               ..........
               """, 1)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........b.
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 2)]
    [Arguments("""
               .aa
               .bb
               """, 2)]
    [Arguments("""
               .aa
               bb.
               """, 2)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               .....a....
               ..........
               ......A...
               ..........
               ..........
               """, 4)]
    [Arguments("""
               ............
               ........0...
               .....0......
               .......0....
               ....0.......
               ......A.....
               ............
               ............
               ........A...
               .........A..
               ............
               ............
               """, 14)]
    [PuzzleInput("Day8.txt", 244)]
    public async Task GetAntinodeCount(string input, int expected)
    {
        await Assert.That(Day8.GetAntinodeCount(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("", 0)]
    [Arguments("aa", 2)]
    [Arguments("""
               .aa
               """, 3)]
    [Arguments("""
               .AA
               """, 3)]
    [Arguments("""
               .00
               """, 3)]
    [Arguments("""
               .bb
               """, 3)]
    [Arguments("""
               .aa.
               """, 4)]
    [Arguments("""
               ..a.a..
               """, 4)]
    [Arguments("""
               a
               .
               a
               .
               .
               .
               .
               """, 4)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ..........
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 5)]
    [Arguments("""
               .a.a..
               """, 3)]
    [Arguments("""
               .a.a.
               """, 2)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 8)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               ..........
               ..........
               ..........
               ..........
               ..........
               """, 3)]
    [Arguments("""
               ..........
               ....a.....
               ........a.
               ..........
               ..........
               """, 3)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........b.
               .....a....
               ..........
               ..........
               ..........
               ..........
               """, 5)]
    [Arguments("""
               .aa
               .bb
               """, 6)]
    [Arguments("""
               .aa
               bb.
               """, 6)]
    [Arguments("""
               ..........
               ..........
               ..........
               ....a.....
               ........a.
               .....a....
               ..........
               ......A...
               ..........
               ..........
               """, 8)]
    [Arguments("""
               ............
               ........0...
               .....0......
               .......0....
               ....0.......
               ......A.....
               ............
               ............
               ........A...
               .........A..
               ............
               ............
               """, 34)]
    [PuzzleInput("Day8.txt", 912)]
    public async Task GetAntinodeCountPart2(string input, int expected)
    {
        await Assert.That(Day8.GetAntinodeCount(input, part2: true)).IsEqualTo(expected);
    }
}