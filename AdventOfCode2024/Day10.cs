using System.Collections.Concurrent;

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

    private static ConcurrentDictionary<Position, List<Position>> GetReachablePeaks(string input)
    {
        var grid = input.ToTwoDimensionalIntArray();

        var reachablePeaks = new ConcurrentDictionary<Position, List<Position>>();

        foreach (Position startPosition in GetStartPositions(grid))
        {
            reachablePeaks.GetOrAdd(startPosition, _ => []).AddRange(Traverse(startPosition, grid, 1));
        }

        return reachablePeaks;
    }

    private static IEnumerable<Position> GetStartPositions(int[,] grid)
    {
        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == 0)
                {
                    yield return new Position(i, j);
                }
            }
        }
    }

    private static List<Position> Traverse(Position startPosition, int[,] grid, int nextHeight)
    {
        if (nextHeight == 10)
        {
            return [startPosition];
        }

        List<Position> positions = [];

        Position top = startPosition with { I = startPosition.I - 1 };
        Position bottom = startPosition with { I = startPosition.I + 1 };
        Position left = startPosition with { J = startPosition.J - 1 };
        Position right = startPosition with { J = startPosition.J + 1 };

        if (top.IsWithinBounds(grid) && grid[top.I, top.J] == nextHeight)
        {
            positions.AddRange(Traverse(top, grid, nextHeight + 1));
        }

        if (bottom.IsWithinBounds(grid) && grid[bottom.I, bottom.J] == nextHeight)
        {
            positions.AddRange(Traverse(bottom, grid, nextHeight + 1));
        }

        if (left.IsWithinBounds(grid) && grid[left.I, left.J] == nextHeight)
        {
            positions.AddRange(Traverse(left, grid, nextHeight + 1));
        }

        if (right.IsWithinBounds(grid) && grid[right.I, right.J] == nextHeight)
        {
            positions.AddRange(Traverse(right, grid, nextHeight + 1));
        }

        return positions;
    }
}