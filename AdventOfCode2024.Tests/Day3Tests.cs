namespace AdventOfCode2024.Tests;

public class Day3Tests
{
    public static IEnumerable<(string, int)> GetSumMultiplicationsData()
    {
        yield return ("mul(2,4)", 8);
        yield return ("mul(3,5)", 15);
        yield return ("mul(10,12)", 120);
        yield return ("mul(2,4)mul(3,5)", 23);
        yield return ("mul[5,4]", 0);
        yield return ("mul(5,4]", 0);
        yield return ("mul[5,4)", 0);
        yield return ("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(3,6]then(mul(1,8)mul(8,5))", 81);
        yield return ("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161);
        yield return (File.ReadAllText("Day3.txt"), 179834255);
    }

    [Test]
    [MethodDataSource(nameof(GetSumMultiplicationsData))]
    public async Task SumMultiplications(string input, int expected)
    {
        await Assert.That(Day3.SumMultiplications(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetSumMultiplicationsWithInstructionsData()
    {
        yield return ("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48);
        yield return (File.ReadAllText("Day3.txt"), 80570939);
    }

    [Test]
    [MethodDataSource(nameof(GetSumMultiplicationsWithInstructionsData))]
    public async Task SumMultiplicationsWithInstructions(string input, int expected)
    {
        await Assert.That(Day3.SumMultiplicationsWithInstructions(input)).IsEqualTo(expected);
    }
}