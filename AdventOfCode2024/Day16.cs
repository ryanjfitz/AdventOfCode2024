using System.Drawing;

namespace AdventOfCode2024;

public static class Day16
{
    public static Point[][] GetPaths(string input)
    {
        var grid = input.ToTwoDimensionalArray<char>();

        var (startPosition, endPosition) = GetStartAndEndPositions(grid);

        var positions = new HashSet<Point>();

        Point lastPosition = startPosition;

        while (!positions.Contains(endPosition))
        {
            For(grid, positions, ref lastPosition, p => p.Y <= grid.GetUpperBound(1), (ref p) => p = p.Right);

            For(grid, positions, ref lastPosition, p => p.Y >= grid.GetLowerBound(1), (ref p) => p = p.Left);

            For(grid, positions, ref lastPosition, p => p.X <= grid.GetUpperBound(0), (ref p) => p = p.Bottom);

            For(grid, positions, ref lastPosition, p => p.X >= grid.GetLowerBound(0), (ref p) => p = p.Top);
        }

        if (positions.Count == 2 && positions.First() == startPosition && positions.Last() == endPosition && !AreAdjacent(startPosition, endPosition))
        {
            positions.Clear();
        }

        return [positions.ToArray()];
    }

    private static (Point startPosition, Point endPosition) GetStartAndEndPositions(char[,] grid)
    {
        Point startPosition = default;
        Point endPosition = default;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 'S')
                {
                    startPosition = new Point(i, j);
                }

                if (grid[i, j] == 'E')
                {
                    endPosition = new Point(i, j);
                }
            }
        }

        return (startPosition, endPosition);
    }

    private delegate void RefAction<T>(ref T param);

    private static void For(char[,] grid, HashSet<Point> positions, ref Point lastPosition, Func<Point, bool> condition, RefAction<Point> iterator)
    {
        for (var currentPosition = lastPosition; condition(currentPosition); iterator(ref currentPosition))
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                continue;
            }

            if (!positions.Add(currentPosition))
            {
                continue;
            }

            lastPosition = currentPosition;
        }
    }

    private static bool AreAdjacent(Point a, Point b)
    {
        return a.Left == b || a.Right == b || a.Top == b || a.Bottom == b;
    }
}