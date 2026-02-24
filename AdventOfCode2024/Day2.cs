namespace AdventOfCode2024;

public static class Day2
{
    public static bool IsSafe(IReadOnlyList<int> report, bool useProblemDampener = false)
    {
        Direction? lastDirection = null;

        for (int level = 0; level < report.Count - 1; level++)
        {
            int diff = report[level] - report[level + 1];

            if (!IsSafe(diff, ref lastDirection))
            {
                return useProblemDampener && IsSafeWithoutLevel(report, level);
            }
        }

        return true;
    }

    private static bool IsSafe(int diff, ref Direction? lastDirection)
    {
        if (diff == 0)
        {
            return false;
        }

        Direction direction = int.IsNegative(diff) ? Direction.Ascending : Direction.Descending;

        if (direction != lastDirection && lastDirection != null)
        {
            return false;
        }

        lastDirection = direction;

        if (Math.Abs(diff) > 3)
        {
            return false;
        }

        return true;
    }

    private static bool IsSafeWithoutLevel(IReadOnlyList<int> report, int level)
    {
        return IsSafe(report.RemoveAt(level).ToList(), useProblemDampener: false) ||
               IsSafe(report.RemoveAt(level + 1).ToList(), useProblemDampener: false) ||
               IsSafe(report.RemoveAt(level - 1).ToList(), useProblemDampener: false);
    }

    private enum Direction
    {
        Ascending,
        Descending
    }

    public static int GetNumberOfSafeReports(string input, bool useProblemDampener = false)
    {
        var reports = ParseInput(input);

        return reports.Count(report => IsSafe(report, useProblemDampener));
    }

    private static IEnumerable<int[]> ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            yield return line.Split(' ').Select(int.Parse).ToArray();
        }
    }
}