namespace AdventOfCode2024;

public static class Day1
{
    public static int GetTotalDistance(int[] leftList, int[] rightList)
    {
        var pairs = leftList.Order().Zip(rightList.Order());

        return pairs.Aggregate(0, (total, pair) => total + Math.Abs(pair.First - pair.Second));
    }

    public static int GetSimilarityScore(int[] leftList, int[] rightList)
    {
        return leftList.Aggregate(0, (total, l) => total + l * rightList.Count(r => r == l));
    }
}