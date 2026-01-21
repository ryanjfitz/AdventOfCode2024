using System.Collections.Concurrent;
using System.Drawing;

namespace AdventOfCode2024;

public static class Day10
{
    public static int GetTotalTrailheadScore(string input)
    {
        return GetReachablePeaks(input).Values.Sum(positions => positions.Distinct().Count());
    }

    public static int GetTotalTrailheadRating(string input)
    {
        return GetReachablePeaks(input).Values.Sum(positions => positions.Count);
    }

    private static ConcurrentDictionary<Point, List<Point>> GetReachablePeaks(string input)
    {
        var grid = input.ToTwoDimensionalArray<int>();

        var reachablePeaks = new ConcurrentDictionary<Point, List<Point>>();

        foreach (Point startPosition in GetStartPositions(grid))
        {
            reachablePeaks.GetOrAdd(startPosition, _ => []).AddRange(Traverse(startPosition, grid, 1));
        }

        return reachablePeaks;
    }

    private static IEnumerable<Point> GetStartPositions(int[,] grid)
    {
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == 0)
                {
                    yield return new Point(i, j);
                }
            }
        }
    }

    private static List<Point> Traverse(Point startPosition, int[,] grid, int nextHeight)
    {
        if (nextHeight == 10)
        {
            return [startPosition];
        }

        List<Point> positions = [];

        Point top = startPosition.Top;
        Point bottom = startPosition.Bottom;
        Point left = startPosition.Left;
        Point right = startPosition.Right;

        if (top.IsWithinBounds(grid) && grid[top.X, top.Y] == nextHeight)
        {
            positions.AddRange(Traverse(top, grid, nextHeight + 1));
        }

        if (bottom.IsWithinBounds(grid) && grid[bottom.X, bottom.Y] == nextHeight)
        {
            positions.AddRange(Traverse(bottom, grid, nextHeight + 1));
        }

        if (left.IsWithinBounds(grid) && grid[left.X, left.Y] == nextHeight)
        {
            positions.AddRange(Traverse(left, grid, nextHeight + 1));
        }

        if (right.IsWithinBounds(grid) && grid[right.X, right.Y] == nextHeight)
        {
            positions.AddRange(Traverse(right, grid, nextHeight + 1));
        }

        return positions;
    }
}