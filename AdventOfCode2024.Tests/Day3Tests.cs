namespace AdventOfCode2024.Tests;

public class Day3Tests
{
    public static TheoryData<string, int> SumMultiplicationsData =>
        new()
        {
            { "mul(2,4)", 8 },
            { "mul(3,5)", 15 },
            { "mul(10,12)", 120 },
            { "mul(2,4)mul(3,5)", 23 },
            { "mul[5,4]", 0 },
            { "mul(5,4]", 0 },
            { "mul[5,4)", 0 },
            { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(3,6]then(mul(1,8)mul(8,5))", 81 },
            { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161 },
            { File.ReadAllText("Day3.txt"), 179834255 }
        };

    [Theory]
    [MemberData(nameof(SumMultiplicationsData))]
    public void SumMultiplications(string input, int expected)
    {
        Assert.Equal(expected, Day3.SumMultiplications(input));
    }

    public static TheoryData<string, int> SumMultiplicationsWithInstructionsData =>
        new()
        {
            { "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48 },
            { File.ReadAllText("Day3.txt"), 80570939 }
        };

    [Theory]
    [MemberData(nameof(SumMultiplicationsWithInstructionsData))]
    public void SumMultiplicationsWithInstructions(string input, int expected)
    {
        Assert.Equal(expected, Day3.SumMultiplicationsWithInstructions(input));
    }
}