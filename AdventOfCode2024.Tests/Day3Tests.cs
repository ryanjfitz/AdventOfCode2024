namespace AdventOfCode2024.Tests;

public class Day3Tests
{
    [Test]
    [Arguments("mul(2,4)", 8)]
    [Arguments("mul(3,5)", 15)]
    [Arguments("mul(10,12)", 120)]
    [Arguments("mul(2,4)mul(3,5)", 23)]
    [Arguments("mul[5,4]", 0)]
    [Arguments("mul(5,4]", 0)]
    [Arguments("mul[5,4)", 0)]
    [Arguments("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(3,6]then(mul(1,8)mul(8,5))", 81)]
    [Arguments("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    [PuzzleInput("Day3.txt", 179834255)]
    public async Task SumMultiplications(string input, int expected)
    {
        await Assert.That(Day3.SumMultiplications(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48)]
    [PuzzleInput("Day3.txt", 80570939)]
    public async Task SumMultiplicationsWithInstructions(string input, int expected)
    {
        await Assert.That(Day3.SumMultiplicationsWithInstructions(input)).IsEqualTo(expected);
    }
}