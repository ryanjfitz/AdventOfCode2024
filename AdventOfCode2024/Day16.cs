using System.Drawing;

namespace AdventOfCode2024;

public class Day16
{
    private readonly char[,] _grid;
    private readonly Point _startPosition;
    private readonly Point _endPosition;
    private Point _lastPosition;

    public Day16(string input)
    {
        _grid = input.ToTwoDimensionalArray<char>();

        (_startPosition, _endPosition) = GetStartAndEndPositions(_grid);
    }

    public Point[][] GetPaths()
    {
        var paths = new HashSet<HashSet<Point>>(new PathEqualityComparer())
        {
            GetPath(),
            GetPath2()
        };

        return paths.All(p => p.Count == 0)
            ? []
            : paths.Select(p => p.ToArray()).ToArray();
    }

    private HashSet<Point> GetPath()
    {
        _lastPosition = _startPosition;

        var path = new HashSet<Point>();

        Point[] lastPath;

        do
        {
            lastPath = path.ToArray();

            For(p => p.Y <= _grid.GetUpperBound(1), (ref p) => p = p.Right, path);

            For(p => p.Y >= _grid.GetLowerBound(1), (ref p) => p = p.Left, path);

            For(p => p.X <= _grid.GetUpperBound(0), (ref p) => p = p.Bottom, path);

            For(p => p.X >= _grid.GetLowerBound(0), (ref p) => p = p.Top, path);
        } while (!path.SetEquals(lastPath));

        if (!path.Contains(_endPosition))
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

    private HashSet<Point> GetPath2()
    {
        _lastPosition = _startPosition;

        var path = new HashSet<Point>();

        Point[] lastPath;

        do
        {
            lastPath = path.ToArray();

            For(p => p.X >= _grid.GetLowerBound(0), (ref p) => p = p.Top, path);

            For(p => p.X <= _grid.GetUpperBound(0), (ref p) => p = p.Bottom, path);

            For(p => p.Y >= _grid.GetLowerBound(1), (ref p) => p = p.Left, path);

            For(p => p.Y <= _grid.GetUpperBound(1), (ref p) => p = p.Right, path);
        } while (!path.SetEquals(lastPath));

        if (!path.Contains(_endPosition))
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

    private void For(Func<Point, bool> condition, RefAction<Point> iterator, HashSet<Point> path)
    {
        for (var currentPosition = _lastPosition; condition(currentPosition); iterator(ref currentPosition))
        {
            if (_grid.GetValueAt(currentPosition) == '#')
            {
                break;
            }

            if (!path.Add(currentPosition) && currentPosition != _lastPosition || currentPosition == _endPosition)
            {
                break;
            }

            _lastPosition = currentPosition;
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