namespace AdventOfCode2024;

public static class Extensions
{
    public static IReadOnlyList<T> RemoveAt<T>(this IEnumerable<T> enumerable, int i)
    {
        var list = enumerable.ToList();
        list.RemoveAt(i);
        return list;
    }

    public static char[,] ToTwoDimensionalArray(this string input)
    {
        StringReader stringReader = new StringReader(input);

        List<char[]> lines = new List<char[]>();

        while (stringReader.Peek() > 0)
        {
            string? line = stringReader.ReadLine();

            if (line != null)
            {
                lines.Add(line.ToCharArray());
            }
        }

        if (lines.Count == 0)
        {
            return new char[0, 0];
        }

        int rowCount = lines.Count;
        int columnCount = lines[0].Length;

        char[,] result = new char[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            var arrayAtRow = lines[row];

            if (arrayAtRow.Length != columnCount)
            {
                throw new ArgumentException("All arrays must be the same length");
            }

            for (int column = 0; column < columnCount; column++)
            {
                result[row, column] = arrayAtRow[column];
            }
        }

        return result;
    }
}