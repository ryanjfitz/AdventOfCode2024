namespace AdventOfCode2024;

public static class Day6
{
    public static int GetDistinctPositionCount(string input)
    {
        var grid = input.ToTwoDimensionalArray();

        var currentPosition = GetStartPosition(grid);

        var traveledPositions = TraverseGrid(grid, currentPosition);

        return traveledPositions.Distinct().Count();
    }

    private static (int i, int j) GetStartPosition(char[,] grid)
    {
        var startPositions = new List<(int i, int j)>();

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == '^')
                {
                    startPositions.Add((i, j));
                }
            }
        }

        if (startPositions.Count != 1)
        {
            throw new ArgumentException("Expected exactly one starting position.");
        }

        return startPositions[0];
    }

    private static IEnumerable<(int, int)> TraverseGrid(char[,] grid, (int i, int j) currentPosition)
    {
        var traveledPositions = new List<(int, int)> { currentPosition };

        Start:
        bool moveRight = false;
        bool moveDown = false;
        bool moveLeft = false;

        for (int i = currentPosition.i - 1; i >= grid.GetLowerBound(0); i--)
        {
            if (grid[i, currentPosition.j] == '#')
            {
                moveRight = true;
                break;
            }

            currentPosition.i = i;
            traveledPositions.Add(currentPosition);
        }

        if (moveRight)
        {
            for (int j = currentPosition.j + 1; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[currentPosition.i, j] == '#')
                {
                    moveDown = true;
                    break;
                }

                currentPosition.j = j;
                traveledPositions.Add(currentPosition);
            }
        }

        if (moveDown)
        {
            for (int i = currentPosition.i + 1; i <= grid.GetUpperBound(0); i++)
            {
                if (grid[i, currentPosition.j] == '#')
                {
                    moveLeft = true;
                    break;
                }

                currentPosition.i = i;
                traveledPositions.Add(currentPosition);
            }
        }

        if (moveLeft)
        {
            for (int j = currentPosition.j - 1; j >= grid.GetLowerBound(1); j--)
            {
                if (grid[currentPosition.i, j] == '#')
                {
                    if (traveledPositions.Count > grid.Length)
                    {
                        throw new InfiniteLoopException();
                    }

                    goto Start;
                }

                currentPosition.j = j;
                traveledPositions.Add(currentPosition);
            }
        }

        return traveledPositions;
    }

    private class InfiniteLoopException : Exception;

    public static int GetInfiniteLoopObstructionCount(string input)
    {
        var grid = input.ToTwoDimensionalArray();

        var startPosition = GetStartPosition(grid);

        var obstructionPositions = new List<(int i, int j)>();

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if ((i, j) == startPosition || grid[i, j] == '#')
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
                    obstructionPositions.Add((i, j));
                }

                grid[i, j] = '.';
            }
        }

        return obstructionPositions.Count;
    }
}