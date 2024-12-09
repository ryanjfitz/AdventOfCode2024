namespace AdventOfCode2024.Tests;

public class Day6Tests
{
    public static TheoryData<string, int> Data =>
        new()
        {
            { "^", 1 },
            {
                """
                .
                ^
                """,
                2
            },
            {
                """
                .
                .
                ^
                """,
                3
            },
            {
                """
                #
                .
                .
                ^
                """,
                3
            },
            {
                """
                #.
                ..
                ..
                ^.
                """,
                4
            },
            {
                """
                #..
                ...
                ...
                ^..
                """,
                5
            },
            {
                """
                #..
                ..#
                ^..
                ...
                """,
                5
            },
            {
                """
                .#..
                ...#
                .^..
                ....
                ..#.
                """,
                7
            },
            {
                """
                ..#..
                ....#
                ..^..
                #....
                ...#.
                """,
                10
            },
            {
                """
                #.#
                ..#
                ^#.
                """,
                3
            },
            {
                """
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
                """,
                41
            },
            { File.ReadAllText("Day6.txt"), 5312 }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void GetDistinctPositionCount(string input, int expected)
    {
        int actual = Day6.GetDistinctPositionCount(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsIfInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Day6.GetDistinctPositionCount(null!));
    }

    public static TheoryData<string, int> InfiniteLoopData => new()
    {
        { "^", 0 },
        {
            """
            .#...
            ....#
            .^...
            .....
            ...#.
            """,
            1
        },
        {
            """
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
            """,
            6
        },
        { File.ReadAllText("Day6.txt"), 1748 }
    };

    [Theory]
    [MemberData(nameof(InfiniteLoopData))]
    public void GetInfiniteLoopObstructionCount(string input, int expected)
    {
        int actual = Day6.GetInfiniteLoopObstructionCount(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("")]
    [InlineData("^^")]
    [InlineData("""
                ^
                ^
                """)]
    public void ThrowsIfThereIsNotExactlyOneStartingPosition(string input)
    {
        var exception = Assert.Throws<ArgumentException>(() => Day6.GetDistinctPositionCount(input));

        Assert.Equal("Expected exactly one starting position.", exception.Message);
    }
}