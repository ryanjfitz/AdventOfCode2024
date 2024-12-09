namespace AdventOfCode2024.Tests;

public class Day2Tests
{
    public static TheoryData<int[], bool> IsSafeData
    {
        get
        {
            var data = new TheoryData<int[], bool>();
            data.Add([1, 2], true);
            data.Add([2, 1], true);
            data.Add([1, 3], true);
            data.Add([1, 4], true);
            data.Add([1, 5], false);
            data.Add([1, 1], false);
            data.Add([1, 2, 3], true);
            data.Add([1, 2, 5], true);
            data.Add([1, 2, 6], false);
            data.Add([6, 2, 1], false);
            data.Add([1, 2, 4, 3], false);
            data.Add([7, 6, 4, 2, 1], true);
            data.Add([1, 3, 6, 7, 9], true);
            data.Add([1, 2, 7, 8, 9], false);
            data.Add([9, 7, 6, 2, 1], false);
            data.Add([1, 3, 2, 4, 5], false);
            data.Add([8, 6, 4, 4, 1], false);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(IsSafeData))]
    public void IsSafe(int[] report, bool expected)
    {
        bool actual = Day2.IsSafe(report);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<IEnumerable<int[]>, int> GetNumberOfSafeReportsData
    {
        get
        {
            var data = new TheoryData<IEnumerable<int[]>, int>();
            data.Add([[1, 9], [3, 8]], 0);
            data.Add([[1, 2], [3, 8]], 1);
            data.Add([[1, 2], [3, 4]], 2);
            data.Add(
            [
                [7, 6, 4, 2, 1],
                [1, 2, 7, 8, 9],
                [9, 7, 6, 2, 1],
                [1, 3, 2, 4, 5],
                [8, 6, 4, 4, 1],
                [1, 3, 6, 7, 9]
            ], 2);
            data.Add(ParsePuzzleInput(), 407);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(GetNumberOfSafeReportsData))]
    public void GetNumberOfSafeReports(IEnumerable<int[]> reports, int expected)
    {
        int actual = Day2.GetNumberOfSafeReports(reports);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int[], bool> IsSafeWithProblemDampenerData
    {
        get
        {
            var data = new TheoryData<int[], bool>();
            data.Add([1, 1, 2], true);
            data.Add([1, 4, 3], true);
            data.Add([1, 5, 6], true);
            data.Add([0, 0, 1], true);
            data.Add([1, 0, 0], true);
            data.Add([1, 5, 4, 7], true);
            data.Add([7, 4, 5, 1], true);
            data.Add([2, 1, 2, 3], true);
            data.Add([2, 3, 2, 1], true);
            data.Add([7, 6, 4, 2, 1], true);
            data.Add([1, 3, 6, 7, 9], true);
            data.Add([1, 2, 7, 8, 9], false);
            data.Add([9, 7, 6, 2, 1], false);
            data.Add([1, 3, 2, 4, 5], true);
            data.Add([8, 6, 4, 4, 1], true);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(IsSafeWithProblemDampenerData))]
    public void IsSafeWithProblemDampener(int[] report, bool expected)
    {
        bool actual = Day2.IsSafe(report, useProblemDampener: true);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<IEnumerable<int[]>, int> GetNumberOfSafeReportsWithProblemDampenerData
    {
        get
        {
            var data = new TheoryData<IEnumerable<int[]>, int>();
            data.Add([[1, 9], [3, 8]], 2);
            data.Add([[1, 2], [3, 8]], 2);
            data.Add([[1, 2], [3, 4]], 2);
            data.Add(
            [
                [7, 6, 4, 2, 1],
                [1, 2, 7, 8, 9],
                [9, 7, 6, 2, 1],
                [1, 3, 2, 4, 5],
                [8, 6, 4, 4, 1],
                [1, 3, 6, 7, 9]
            ], 4);
            data.Add(ParsePuzzleInput(), 459);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(GetNumberOfSafeReportsWithProblemDampenerData))]
    public void GetNumberOfSafeReportsWithProblemDampener(IEnumerable<int[]> reports, int expected)
    {
        int actual = Day2.GetNumberOfSafeReports(reports, useProblemDampener: true);

        Assert.Equal(expected, actual);
    }

    private static IEnumerable<int[]> ParsePuzzleInput()
    {
        var lines = File.ReadAllLines("Day2.txt");

        foreach (var line in lines)
        {
            yield return line.Split(' ').Select(int.Parse).ToArray();
        }
    }
}