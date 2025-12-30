using System.Drawing;

namespace AdventOfCode2024;

public static class Day16
{
    public static IReadOnlyCollection<Point> GetPaths(string input)
    {
        var grid = input.ToTwoDimensionalArray<char>();

        var (startPosition, endPosition) = GetStartAndEndPositions(grid);

        bool wallEncountered = false;

        var positions = new HashSet<Point>();

        Point currentPosition;
        Point lastPosition = default;

        for (currentPosition = startPosition; currentPosition.Y <= endPosition.Y; currentPosition = currentPosition.Right)
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                wallEncountered = true;
                continue;
            }

            lastPosition = currentPosition;
            positions.Add(currentPosition);
        }

        for (currentPosition = startPosition; currentPosition.Y >= endPosition.Y; currentPosition = currentPosition.Left)
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                wallEncountered = true;
                continue;
            }

            lastPosition = currentPosition;
            positions.Add(currentPosition);
        }

        for (currentPosition = !positions.Contains(endPosition) ? lastPosition : startPosition;
             currentPosition.X <= endPosition.X;
             currentPosition = currentPosition.Bottom)
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                wallEncountered = true;
                continue;
            }

            positions.Add(currentPosition);
        }

        for (currentPosition = !positions.Contains(endPosition) ? lastPosition : startPosition;
             currentPosition.X >= endPosition.X;
             currentPosition = currentPosition.Top)
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                wallEncountered = true;
                continue;
            }

            positions.Add(currentPosition);
        }

        if (wallEncountered && positions.Count == 2 && positions.First() == startPosition && positions.Last() == endPosition)
        {
            positions.Clear();
        }

        return positions;
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
}