namespace AdventOfCode2024;

public static class Extensions
{
    public static IReadOnlyList<T> RemoveAt<T>(this IEnumerable<T> enumerable, int i)
    {
        var list = enumerable.ToList();
        list.RemoveAt(i);
        return list;
    }

    public static char[,] ToTwoDimensionalCharArray(this string input)
    {
        string[] lines = input.Split(Environment.NewLine);

        int rowCount = lines.Length;
        int columnCount = lines[0].Length;

        char[,] result = new char[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                result[row, column] = lines[row][column];
            }
        }

        return result;
    }
}