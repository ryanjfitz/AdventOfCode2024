namespace AdventOfCode2024;

public static class Day2
{
    public static bool IsSafe(IReadOnlyList<int> report, bool useProblemDampener = false)
    {
        Direction? lastDirection = null;

        for (int level = 0; level < report.Count - 1; level++)
        {
            int diff = report[level] - report[level + 1];

            if (diff == 0)
            {
                if (useProblemDampener)
                {
                    return IsSafeWithoutLevel(report, level);
                }

                return false;
            }

            Direction direction = int.IsNegative(diff) ? Direction.Ascending : Direction.Descending;

            if (direction != lastDirection && lastDirection != null)
            {
                if (useProblemDampener)
                {
                    return IsSafeWithoutLevel(report, level);
                }

                return false;
            }

            lastDirection = direction;

            if (Math.Abs(diff) > 3)
            {
                if (useProblemDampener)
                {
                    return IsSafeWithoutLevel(report, level);
                }

                return false;
            }
        }

        return true;
    }

    private static bool IsSafeWithoutLevel(IReadOnlyList<int> report, int level)
    {
        return level >= 0 && IsSafe(report.RemoveAt(level), useProblemDampener: false) ||
               level + 1 >= 0 && IsSafe(report.RemoveAt(level + 1), useProblemDampener: false) ||
               level - 1 >= 0 && IsSafe(report.RemoveAt(level - 1), useProblemDampener: false);
    }

    private enum Direction
    {
        Ascending,
        Descending
    }

    public static int GetNumberOfSafeReports(IEnumerable<int[]> reports, bool useProblemDampener = false)
    {
        return reports.Count(report => IsSafe(report, useProblemDampener));
    }
}