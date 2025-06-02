namespace AdventOfCode2024.Tests;

public class Day13Tests
{
    [Test]
    [Arguments("""
               Button A: X+94, Y+34
               Button B: X+22, Y+67
               Prize: X=8400, Y=5400
               """, 280)]
    [Arguments("""
               Button A: X+26, Y+66
               Button B: X+67, Y+21
               Prize: X=12748, Y=12176
               """, 0)]
    [Arguments("""
               Button A: X+17, Y+86
               Button B: X+84, Y+37
               Prize: X=7870, Y=6450
               """, 200)]
    [Arguments("""
               Button A: X+69, Y+23
               Button B: X+27, Y+71
               Prize: X=18641, Y=10279
               """, 0)]
    [Arguments("""
               Button A: X+94, Y+34
               Button B: X+22, Y+67
               Prize: X=8400, Y=5400

               Button A: X+26, Y+66
               Button B: X+67, Y+21
               Prize: X=12748, Y=12176

               Button A: X+17, Y+86
               Button B: X+84, Y+37
               Prize: X=7870, Y=6450

               Button A: X+69, Y+23
               Button B: X+27, Y+71
               Prize: X=18641, Y=10279
               """, 480)]
    [PuzzleInputLong("Day13.txt", 32026)]
    public async Task GetMinimumNumberOfTokensToWin(string input, long expected)
    {
        await Assert.That(Day13.GetMinimumNumberOfTokensToWin(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("""
               Button A: X+94, Y+34
               Button B: X+22, Y+67
               Prize: X=8400, Y=5400
               """, 0)]
    [Arguments("""
               Button A: X+26, Y+66
               Button B: X+67, Y+21
               Prize: X=12748, Y=12176
               """, 459236326669)]
    [Arguments("""
               Button A: X+17, Y+86
               Button B: X+84, Y+37
               Prize: X=7870, Y=6450
               """, 0)]
    [Arguments("""
               Button A: X+69, Y+23
               Button B: X+27, Y+71
               Prize: X=18641, Y=10279
               """, 416082282239)]
    [Arguments("""
               Button A: X+94, Y+34
               Button B: X+22, Y+67
               Prize: X=8400, Y=5400

               Button A: X+26, Y+66
               Button B: X+67, Y+21
               Prize: X=12748, Y=12176

               Button A: X+17, Y+86
               Button B: X+84, Y+37
               Prize: X=7870, Y=6450

               Button A: X+69, Y+23
               Button B: X+27, Y+71
               Prize: X=18641, Y=10279
               """, 875318608908)]
    [PuzzleInputLong("Day13.txt", 89013607072065)]
    public async Task GetMinimumNumberOfTokensToWinPart2(string input, long expected)
    {
        await Assert.That(Day13.GetMinimumNumberOfTokensToWin(input, true)).IsEqualTo(expected);
    }
}