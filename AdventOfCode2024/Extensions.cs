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

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this ICollection<T> list, int? length = null)
    {
        length ??= list.Count;

        if (length == 1)
        {
            return list.Select(t => new[] { t });
        }

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat([t2]));
    }
}