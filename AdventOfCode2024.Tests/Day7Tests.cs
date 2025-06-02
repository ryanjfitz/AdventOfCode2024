namespace AdventOfCode2024.Tests;

public class Day7Tests
{
    private static readonly string PuzzleInput = File.ReadAllText("Day7.txt");

    public static IEnumerable<(string, long)> GetData()
    {
        yield return ("0: 0 0", 0);
        yield return ("2: 1 1", 2);
        yield return ("5: 2 3", 5);
        yield return ("14: 2 7", 14);
        yield return ("17: 2 7 3", 17);
        yield return ("27: 2 7 3", 27);
        yield return ("13: 3 3 2 2", 13);
        yield return ("""
                      17: 2 7 3
                      27: 2 7 3
                      """, 44);
        yield return ("""
                      190: 10 19
                      3267: 81 40 27
                      83: 17 5
                      156: 15 6
                      7290: 6 8 6 15
                      161011: 16 10 13
                      192: 17 8 14
                      21037: 9 7 18 13
                      292: 11 6 16 20
                      """, 3749);
        yield return (PuzzleInput, 5837374519342);
    }

    [Test]
    [MethodDataSource(nameof(GetData))]
    public async Task GetTotalCalibrationResult(string input, long expected)
    {
        await Assert.That(Day7.GetTotalCalibrationResult(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, long)> GetConcatenatedData()
    {
        yield return ("156: 15 6", 156);
        yield return ("7290: 6 8 6 15", 7290);
        yield return ("192: 17 8 14", 192);
        yield return ("""
                      190: 10 19
                      3267: 81 40 27
                      83: 17 5
                      156: 15 6
                      7290: 6 8 6 15
                      161011: 16 10 13
                      192: 17 8 14
                      21037: 9 7 18 13
                      292: 11 6 16 20
                      """, 11387);
        yield return (PuzzleInput, 492383931650959);
    }

    [Test]
    [MethodDataSource(nameof(GetConcatenatedData))]
    public async Task GetTotalConcatenatedCalibrationResult(string input, long expected)
    {
        await Assert.That(Day7.GetTotalCalibrationResult(input, allowConcatenation: true)).IsEqualTo(expected);
    }
}