namespace AdventOfCode2024;

public static class Extensions
{
    public static T[] RemoveAt<T>(this T[] array, int i)
    {
        return array.Where((_, index) => index != i).ToArray();
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

    internal static T GetValueAt<T>(this T[,] array, Position position)
    {
        return array[position.I, position.J];
    }

    internal static void SetValueAt<T>(this T[,] array, Position position, T value)
    {
        array[position.I, position.J] = value;
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
}