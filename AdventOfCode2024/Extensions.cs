using System.Drawing;

namespace AdventOfCode2024;

public static class Extensions
{
    public static IEnumerable<T> RemoveAt<T>(this IEnumerable<T> enumerable, int index)
    {
        return enumerable.Where((_, i) => i != index);
    }

    public static T[,] ToTwoDimensionalArray<T>(this string input)
    {
        string[] lines = input.Split(Environment.NewLine);

        int rowCount = lines.Length;
        int columnCount = lines[0].Length;

        T[,] result = new T[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                object value = null!;

                if (typeof(T) == typeof(char))
                {
                    value = lines[row][column];
                }
                else if (typeof(T) == typeof(int))
                {
                    value = (int)char.GetNumericValue(lines[row][column]);
                }

                result[row, column] = (T)value;
            }
        }

        return result;
    }

    extension<T>(T[,] array)
    {
        internal T GetValueAt(Point position)
        {
            return array[position.X, position.Y];
        }

        internal void SetValueAt(Point position, T value)
        {
            array[position.X, position.Y] = value;
        }
    }

    public static T[][] GetPermutations<T>(this ICollection<T> list)
    {
        return GetPermutations(list, list.Count)
            .Select(permutation => permutation.ToArray())
            .ToArray();
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(ICollection<T> list, int length)
    {
        if (length == 1)
        {
            return list.Select(listItem => new[] { listItem });
        }

        return GetPermutations(list, length - 1)
            .SelectMany(permutation => list.Where(listItem => !permutation.Contains(listItem)),
                (permutation, listItem) => permutation.Concat([listItem]));
    }

    extension(Point point)
    {
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public Point Top => point with { X = point.X - 1 };

        public Point Bottom => point with { X = point.X + 1 };

        public Point Left => point with { Y = point.Y - 1 };

        public Point Right => point with { Y = point.Y + 1 };

        public bool IsWithinBounds<T>(T[,] grid)
        {
            return point.X >= grid.GetLowerBound(0) &&
                   point.Y >= grid.GetLowerBound(1) &&
                   point.X <= grid.GetUpperBound(0) &&
                   point.Y <= grid.GetUpperBound(1);
        }
    }
}