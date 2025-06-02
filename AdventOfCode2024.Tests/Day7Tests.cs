namespace AdventOfCode2024.Tests;

public class Day7Tests
{
    [Test]
    [Arguments("0: 0 0", 0)]
    [Arguments("2: 1 1", 2)]
    [Arguments("5: 2 3", 5)]
    [Arguments("14: 2 7", 14)]
    [Arguments("17: 2 7 3", 17)]
    [Arguments("27: 2 7 3", 27)]
    [Arguments("13: 3 3 2 2", 13)]
    [Arguments("""
               17: 2 7 3
               27: 2 7 3
               """, 44)]
    [Arguments("""
               190: 10 19
               3267: 81 40 27
               83: 17 5
               156: 15 6
               7290: 6 8 6 15
               161011: 16 10 13
               192: 17 8 14
               21037: 9 7 18 13
               292: 11 6 16 20
               """, 3749)]
    [PuzzleInputLong("Day7.txt", 5837374519342)]
    public async Task GetTotalCalibrationResult(string input, long expected)
    {
        await Assert.That(Day7.GetTotalCalibrationResult(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("156: 15 6", 156)]
    [Arguments("7290: 6 8 6 15", 7290)]
    [Arguments("192: 17 8 14", 192)]
    [Arguments("""
               190: 10 19
               3267: 81 40 27
               83: 17 5
               156: 15 6
               7290: 6 8 6 15
               161011: 16 10 13
               192: 17 8 14
               21037: 9 7 18 13
               292: 11 6 16 20
               """, 11387)]
    [PuzzleInputLong("Day7.txt", 492383931650959)]
    public async Task GetTotalConcatenatedCalibrationResult(string input, long expected)
    {
        await Assert.That(Day7.GetTotalCalibrationResult(input, allowConcatenation: true)).IsEqualTo(expected);
    }
}