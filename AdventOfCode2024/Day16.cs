using System.Drawing;

namespace AdventOfCode2024;

public static class Day16
{
    public static Point[][] GetPaths(string input)
    {
        var grid = input.ToTwoDimensionalArray<char>();

        var (startPosition, endPosition) = GetStartAndEndPositions(grid);

        var paths = new HashSet<HashSet<Point>>(new PathEqualityComparer())
        {
            GetPath(grid, startPosition, endPosition),
            GetPath2(grid, startPosition, endPosition)
        };

        return paths.All(p => p.Count == 0)
            ? []
            : paths.Select(p => p.ToArray()).ToArray();
    }

    private static HashSet<Point> GetPath(char[,] grid, Point startPosition, Point endPosition)
    {
        var lastPosition = startPosition;

        var path = new HashSet<Point>();

        Point[] lastPath;

        do
        {
            lastPath = path.ToArray();

            For(p => p.Y <= grid.GetUpperBound(1), (ref p) => p = p.Right, ref lastPosition, grid, path, endPosition);

            For(p => p.Y >= grid.GetLowerBound(1), (ref p) => p = p.Left, ref lastPosition, grid, path, endPosition);

            For(p => p.X <= grid.GetUpperBound(0), (ref p) => p = p.Bottom, ref lastPosition, grid, path, endPosition);

            For(p => p.X >= grid.GetLowerBound(0), (ref p) => p = p.Top, ref lastPosition, grid, path, endPosition);
        } while (!path.SetEquals(lastPath));

        if (!path.Contains(endPosition))
        {
            path.Clear();
        }

        for (int i = 0; i < path.Count - 1; i++)
        {
            if (!AreAdjacent(path.ElementAt(i), path.ElementAt(i + 1)))
            {
                path.Clear();
                break;
            }
        }

        return path;
    }

    private static HashSet<Point> GetPath2(char[,] grid, Point startPosition, Point endPosition)
    {
        var lastPosition = startPosition;

        var path = new HashSet<Point>();

        Point[] lastPath;

        do
        {
            lastPath = path.ToArray();

            For(p => p.X >= grid.GetLowerBound(0), (ref p) => p = p.Top, ref lastPosition, grid, path, endPosition);

            For(p => p.X <= grid.GetUpperBound(0), (ref p) => p = p.Bottom, ref lastPosition, grid, path, endPosition);

            For(p => p.Y >= grid.GetLowerBound(1), (ref p) => p = p.Left, ref lastPosition, grid, path, endPosition);

            For(p => p.Y <= grid.GetUpperBound(1), (ref p) => p = p.Right, ref lastPosition, grid, path, endPosition);
        } while (!path.SetEquals(lastPath));

        if (!path.Contains(endPosition))
        {
            path.Clear();
        }

        for (int i = 0; i < path.Count - 1; i++)
        {
            if (!AreAdjacent(path.ElementAt(i), path.ElementAt(i + 1)))
            {
                path.Clear();
                break;
            }
        }

        return path;
    }

    private static void For(Func<Point, bool> condition, RefAction<Point> iterator, ref Point lastPosition, char[,] grid, HashSet<Point> path,
        Point endPosition)
    {
        for (var currentPosition = lastPosition; condition(currentPosition); iterator(ref currentPosition))
        {
            if (grid.GetValueAt(currentPosition) == '#')
            {
                break;
            }

            if (!path.Add(currentPosition) && currentPosition != lastPosition || currentPosition == endPosition)
            {
                break;
            }

            lastPosition = currentPosition;
        }
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

    private static bool AreAdjacent(Point a, Point b)
    {
        return a.Left == b || a.Right == b || a.Top == b || a.Bottom == b;
    }

    private class PathEqualityComparer : IEqualityComparer<HashSet<Point>>
    {
        public bool Equals(HashSet<Point>? x, HashSet<Point>? y)
        {
            return x!.SetEquals(y!);
        }

        public int GetHashCode(HashSet<Point> obj)
        {
            int hashCode = 0;

            foreach (Point point in obj)
            {
                hashCode ^= point.GetHashCode();
            }

            return hashCode;
        }
    }
}