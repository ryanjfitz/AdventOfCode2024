namespace AdventOfCode2024.Tests;

public class Day10Tests
{
    public static TheoryData<string, int> ScoreData => new()
    {
        { "0123456789", 1 },
        { "9876543210", 1 },
        { "123456789", 0 },
        { "012345678", 0 },
        { "5678901234", 0 },
        { "9876543210123456789", 2 },
        {
            """
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
            """,
            1
        },
        {
            """
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
            """,
            1
        },
        {
            """
            0123456789
            9876543210
            """,
            4
        },
        {
            """
            01234
            98765
            """,
            1
        },
        {
            """
            01
            32
            45
            76
            89
            """,
            1
        },
        {
            """
            ...0...
            ...1...
            ...2...
            6543456
            7.....7
            8.....8
            9.....9
            """,
            2
        },
        {
            """
            ..90..9
            ...1.98
            ...2..7
            6543456
            765.987
            876....
            987....
            """,
            4
        },
        {
            """
            10..9..
            2...8..
            3...7..
            4567654
            ...8..3
            ...9..2
            .....01
            """,
            3
        },
        {
            """
            89010123
            78121874
            87430965
            96549874
            45678903
            32019012
            01329801
            10456732
            """,
            36
        },
        { File.ReadAllText("Day10.txt"), 733 }
    };

    [Theory]
    [MemberData(nameof(ScoreData))]
    public void GetTotalTrailheadScore(string input, int expected)
    {
        Assert.Equal(expected, Day10.GetTotalTrailheadScore(input));
    }

    public static TheoryData<string, int> RatingData => new()
    {
        {
            """
            .....0.
            ..4321.
            ..5..2.
            ..6543.
            ..7..4.
            ..8765.
            ..9....
            """,
            3
        },
        {
            """
            ..90..9
            ...1.98
            ...2..7
            6543456
            765.987
            876....
            987....
            """,
            13
        },
        {
            """
            012345
            123456
            234567
            345678
            4.6789
            56789.
            """,
            227
        },
        {
            """
            89010123
            78121874
            87430965
            96549874
            45678903
            32019012
            01329801
            10456732
            """,
            81
        },
        { File.ReadAllText("Day10.txt"), 1514 }
    };

    [Theory]
    [MemberData(nameof(RatingData))]
    public void GetTotalTrailheadRating(string input, int expected)
    {
        Assert.Equal(expected, Day10.GetTotalTrailheadRating(input));
    }
}