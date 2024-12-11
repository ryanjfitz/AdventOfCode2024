namespace AdventOfCode2024.Tests;

public class Day7Tests
{
    public static TheoryData<string, long> Data =>
        new()
        {
            { "0: 0 0", 0 },
            { "2: 1 1", 2 },
            { "5: 2 3", 5 },
            { "14: 2 7", 14 },
            { "17: 2 7 3", 17 },
            { "27: 2 7 3", 27 },
            { "13: 3 3 2 2", 13 },
            {
                """
                17: 2 7 3
                27: 2 7 3
                """,
                44
            },
            {
                """
                190: 10 19
                3267: 81 40 27
                83: 17 5
                156: 15 6
                7290: 6 8 6 15
                161011: 16 10 13
                192: 17 8 14
                21037: 9 7 18 13
                292: 11 6 16 20
                """,
                3749
            },
            { File.ReadAllText("Day7.txt"), 5837374519342 }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void GetTotalCalibrationResult(string input, long expected)
    {
        long actual = Day7.GetTotalCalibrationResult(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, long> ConcatenatedData =>
        new()
        {
            { "156: 15 6", 156 },
            { "7290: 6 8 6 15", 7290 },
            { "192: 17 8 14", 192 },
            {
                """
                190: 10 19
                3267: 81 40 27
                83: 17 5
                156: 15 6
                7290: 6 8 6 15
                161011: 16 10 13
                192: 17 8 14
                21037: 9 7 18 13
                292: 11 6 16 20
                """,
                11387
            },
            { File.ReadAllText("Day7.txt"), 492383931650959 }
        };

    [Theory]
    [MemberData(nameof(ConcatenatedData))]
    public void GetTotalConcatenatedCalibrationResult(string input, long expected)
    {
        long actual = Day7.GetTotalCalibrationResult(input, allowConcatenation: true);

        Assert.Equal(expected, actual);
    }
}