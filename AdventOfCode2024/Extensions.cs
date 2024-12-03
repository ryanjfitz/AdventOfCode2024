namespace AdventOfCode2024;

internal static class Extensions
{
    public static IReadOnlyList<T> RemoveAt<T>(this IEnumerable<T> enumerable, int i)
    {
        var list = enumerable.ToList();
        list.RemoveAt(i);
        return list;
    }
}