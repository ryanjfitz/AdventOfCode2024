namespace AdventOfCode2024.Tests;

public class Day4Tests
{
    public static IEnumerable<(string, int)> GetXmasData()
    {
        yield return ("""
                      ....
                      ....
                      ....
                      ....
                      """, 0);
        yield return ("""
                      XMAS
                      ....
                      ....
                      ....
                      """, 1);
        yield return ("""
                      XMA.
                      ....
                      ....
                      ....
                      """, 0);
        yield return ("""
                      SAMX
                      ....
                      ....
                      ....
                      """, 1);
        yield return ("""
                      XMAS
                      XMAS
                      ....
                      ....
                      """, 2);
        yield return ("""
                      XMASXMAS
                      ........
                      ........
                      ........
                      ........
                      ........
                      ........
                      """, 2);
        yield return ("""
                      SAMXSAMX
                      ........
                      ........
                      ........
                      ........
                      ........
                      ........
                      """, 2);
        yield return ("""
                      XMASSAMX
                      ........
                      ........
                      ........
                      ........
                      ........
                      ........
                      ........
                      """, 2);
        yield return ("""
                      X...
                      .M..
                      ..A.
                      ...S
                      """, 1);
        yield return ("""
                      ...X
                      ..M.
                      .A..
                      S...
                      """, 1);
        yield return ("""
                      ...S
                      ..A.
                      .M..
                      X...
                      """, 1);
        yield return ("""
                      S...
                      .A..
                      ..M.
                      ...X
                      """, 1);
        yield return ("""
                      X..S
                      .MA.
                      .MA.
                      X..S
                      """, 2);
        yield return ("""
                      X...
                      M...
                      A...
                      S...
                      """, 1);
        yield return ("""
                      ...S
                      ...A
                      ...M
                      ...X
                      """, 1);
        yield return ("""
                      XMASAMX
                      .......
                      .......
                      .......
                      .......
                      .......
                      .......
                      """, 2);
        yield return ("""
                      X......
                      M......
                      A......
                      S......
                      A......
                      M......
                      X......
                      """, 2);
        yield return ("""
                      MMMSXXMASM
                      MSAMXMSMSA
                      AMXSXMAAMM
                      MSAMASMSMX
                      XMASAMXAMM
                      XXAMMXXAMA
                      SMSMSASXSS
                      SAXAMASAAA
                      MAMMMXMMMM
                      MXMXAXMASX
                      """, 18);
        yield return (File.ReadAllText("Day4.txt"), 2633);
    }

    [Test]
    [MethodDataSource(nameof(GetXmasData))]
    public async Task GetXmasCount(string input, int expected)
    {
        await Assert.That(Day4.GetXmasCount(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetXShapedMasData()
    {
        yield return ("""
                      M.S
                      .A.
                      M.S
                      """, 1);
        yield return ("""
                      S.S
                      .A.
                      M.M
                      """, 1);
        yield return ("""
                      S.M
                      .A.
                      S.M
                      """, 1);
        yield return ("""
                      M.M
                      .A.
                      S.S
                      """, 1);
        yield return ("""
                      MMMSXXMASM
                      MSAMXMSMSA
                      AMXSXMAAMM
                      MSAMASMSMX
                      XMASAMXAMM
                      XXAMMXXAMA
                      SMSMSASXSS
                      SAXAMASAAA
                      MAMMMXMMMM
                      MXMXAXMASX
                      """, 9);
        yield return (File.ReadAllText("Day4.txt"), 1936);
    }

    [Test]
    [MethodDataSource(nameof(GetXShapedMasData))]
    public async Task GetXShapedMasCount(string input, int expected)
    {
        await Assert.That(Day4.GetXShapedMasCount(input)).IsEqualTo(expected);
    }
}