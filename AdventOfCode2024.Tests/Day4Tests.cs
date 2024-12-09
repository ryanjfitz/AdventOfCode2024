namespace AdventOfCode2024.Tests;

public class Day4Tests
{
    public static TheoryData<char[,], int> XmasData =>
        new()
        {
            {
                new[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                0
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', 'S' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                1
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                0
            },
            {
                new[,]
                {
                    { 'S', 'A', 'M', 'X' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                1
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', 'S' },
                    { 'X', 'M', 'A', 'S' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                2
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', 'S', 'X', 'M', 'A', 'S' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' }
                },
                2
            },
            {
                new[,]
                {
                    { 'S', 'A', 'M', 'X', 'S', 'A', 'M', 'X' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' }
                },
                2
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.', '.' }
                },
                2
            },
            {
                new[,]
                {
                    { 'X', '.', '.', '.' },
                    { '.', 'M', '.', '.' },
                    { '.', '.', 'A', '.' },
                    { '.', '.', '.', 'S' }
                },
                1
            },
            {
                new[,]
                {
                    { '.', '.', '.', 'X' },
                    { '.', '.', 'M', '.' },
                    { '.', 'A', '.', '.' },
                    { 'S', '.', '.', '.' }
                },
                1
            },
            {
                new[,]
                {
                    { '.', '.', '.', 'S' },
                    { '.', '.', 'A', '.' },
                    { '.', 'M', '.', '.' },
                    { 'X', '.', '.', '.' }
                },
                1
            },
            {
                new[,]
                {
                    { 'S', '.', '.', '.' },
                    { '.', 'A', '.', '.' },
                    { '.', '.', 'M', '.' },
                    { '.', '.', '.', 'X' }
                },
                1
            },
            {
                new[,]
                {
                    { 'X', '.', '.', 'S' },
                    { '.', 'M', 'A', '.' },
                    { '.', 'M', 'A', '.' },
                    { 'X', '.', '.', 'S' }
                },
                2
            },
            {
                new[,]
                {
                    { 'X', '.', '.', '.' },
                    { 'M', '.', '.', '.' },
                    { 'A', '.', '.', '.' },
                    { 'S', '.', '.', '.' }
                },
                1
            },
            {
                new[,]
                {
                    { '.', '.', '.', 'S' },
                    { '.', '.', '.', 'A' },
                    { '.', '.', '.', 'M' },
                    { '.', '.', '.', 'X' }
                },
                1
            },
            {
                new[,]
                {
                    { 'X', 'M', 'A', 'S', 'A', 'M', 'X' },
                    { '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.' },
                    { '.', '.', '.', '.', '.', '.', '.' }
                },
                2
            },
            {
                new[,]
                {
                    { 'X', '.', '.', '.', '.', '.', '.' },
                    { 'M', '.', '.', '.', '.', '.', '.' },
                    { 'A', '.', '.', '.', '.', '.', '.' },
                    { 'S', '.', '.', '.', '.', '.', '.' },
                    { 'A', '.', '.', '.', '.', '.', '.' },
                    { 'M', '.', '.', '.', '.', '.', '.' },
                    { 'X', '.', '.', '.', '.', '.', '.' }
                },
                2
            },
            {
                PuzzleInputToSquareCharArray("""
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
                                             """),
                18
            },
            {
                PuzzleInputToSquareCharArray(File.ReadAllText("Day4.txt")),
                2633
            }
        };

    private static char[,] PuzzleInputToSquareCharArray(string input)
    {
        StringReader stringReader = new StringReader(input);

        List<char[]> lines = new List<char[]>();

        while (stringReader.Peek() > 0)
        {
            string? line = stringReader.ReadLine();

            if (line != null)
            {
                lines.Add(line.ToCharArray());
            }
        }

        int rowCount = ((IReadOnlyList<char[]>)lines).Count;
        int columnCount = ((IReadOnlyList<char[]>)lines)[0].Length;

        char[,] result = new char[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            var arrayAtRow = ((IReadOnlyList<char[]>)lines)[row];

            if (arrayAtRow.Length != columnCount)
            {
                throw new ArgumentException("All arrays must be the same length");
            }

            for (int column = 0; column < columnCount; column++)
            {
                result[row, column] = arrayAtRow[column];
            }
        }

        return result;
    }

    [Theory]
    [MemberData(nameof(XmasData))]
    public void GetXmasCount(char[,] input, int expected)
    {
        int actual = Day4.GetXmasCount(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsWhenInputIsNotTwoDimensionalSquareArray()
    {
        var exception = Assert.Throws<ArgumentException>(() => Day4.GetXmasCount(new[,]
        {
            { '.', '.' }
        }));

        Assert.Equal("Input must be a two-dimensional square array.", exception.Message);
    }

    public static TheoryData<char[,], int> XShapedMasData => new()
    {
        {
            new[,]
            {
                { 'M', '.', 'S' },
                { '.', 'A', '.' },
                { 'M', '.', 'S' }
            },
            1
        },
        {
            new[,]
            {
                { 'S', '.', 'S' },
                { '.', 'A', '.' },
                { 'M', '.', 'M' }
            },
            1
        },
        {
            new[,]
            {
                { 'S', '.', 'M' },
                { '.', 'A', '.' },
                { 'S', '.', 'M' }
            },
            1
        },
        {
            new[,]
            {
                { 'M', '.', 'M' },
                { '.', 'A', '.' },
                { 'S', '.', 'S' }
            },
            1
        },
        {
            PuzzleInputToSquareCharArray("""
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
                                         """),
            9
        },
        {
            PuzzleInputToSquareCharArray(File.ReadAllText("Day4.txt")),
            1936
        }
    };

    [Theory]
    [MemberData(nameof(XShapedMasData))]
    public void GetXShapedMasCount(char[,] input, int expected)
    {
        int actual = Day4.GetXShapedMasCount(input);

        Assert.Equal(expected, actual);
    }
}