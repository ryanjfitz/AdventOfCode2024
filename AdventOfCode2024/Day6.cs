using System.Drawing;

namespace AdventOfCode2024;

public static class Day6
{
    public static int GetDistinctPositionCount(string input)
    {
        var grid = input.ToTwoDimensionalArray<char>();

        var currentPosition = GetStartPosition(grid);

        var traveledPositions = TraverseGrid(grid, currentPosition);

        return traveledPositions.Distinct().Count();
    }

    private static Point GetStartPosition(char[,] grid)
    {
        var startPositions = new List<Point>();

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == '^')
                {
                    startPositions.Add(new Point(i, j));
                }
            }
        }

        if (startPositions.Count != 1)
        {
            throw new ArgumentException("Expected exactly one starting position.");
        }

        return startPositions[0];
    }

    private static IEnumerable<Point> TraverseGrid(char[,] grid, Point currentPosition)
    {
        var traveledPositions = new List<Point> { currentPosition };

        Start:
        bool moveRight = false;
        bool moveDown = false;
        bool moveLeft = false;

        for (int i = currentPosition.X - 1; i >= grid.GetLowerBound(0); i--)
        {
            if (grid[i, currentPosition.Y] == '#')
            {
                moveRight = true;
                break;
            }

            currentPosition.X = i;
            traveledPositions.Add(currentPosition);
        }

        if (moveRight)
        {
            for (int j = currentPosition.Y + 1; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[currentPosition.X, j] == '#')
                {
                    moveDown = true;
                    break;
                }

                currentPosition.Y = j;
                traveledPositions.Add(currentPosition);
            }
        }

        if (moveDown)
        {
            for (int i = currentPosition.X + 1; i <= grid.GetUpperBound(0); i++)
            {
                if (grid[i, currentPosition.Y] == '#')
                {
                    moveLeft = true;
                    break;
                }

                currentPosition.X = i;
                traveledPositions.Add(currentPosition);
            }
        }

        if (moveLeft)
        {
            for (int j = currentPosition.Y - 1; j >= grid.GetLowerBound(1); j--)
            {
                if (grid[currentPosition.X, j] == '#')
                {
                    if (traveledPositions.Count > grid.Length)
                    {
                        throw new InfiniteLoopException();
                    }

                    goto Start;
                }

                currentPosition.Y = j;
                traveledPositions.Add(currentPosition);
            }
        }

        return traveledPositions;
    }

    private class InfiniteLoopException : Exception;

    public static int GetInfiniteLoopObstructionCount(string input)
    {
        var grid = input.ToTwoDimensionalArray<char>();

        var startPosition = GetStartPosition(grid);

        var obstructionPositions = new List<Point>();

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                var currentPosition = new Point(i, j);

                if (currentPosition == startPosition || grid[i, j] == '#')
                {
                    continue;
                }

                grid[i, j] = '#';

                try
                {
                    TraverseGrid(grid, startPosition);
                }
                catch (InfiniteLoopException)
                {
                    obstructionPositions.Add(currentPosition);
                }

                grid[i, j] = '.';
            }
        }

        return obstructionPositions.Count;
    }
}