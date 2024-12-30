namespace AdventOfCode2024;

public static class Day1
{
    public static int GetTotalDistance(string input)
    {
        var (leftList, rightList) = ParseInput(input);

        var pairs = leftList.Order().Zip(rightList.Order());

        return pairs.Aggregate(0, (total, pair) => total + Math.Abs(pair.First - pair.Second));
    }

    public static int GetSimilarityScore(string input)
    {
        var (leftList, rightList) = ParseInput(input);

        return leftList.Aggregate(0, (total, l) => total + l * rightList.Count(r => r == l));
    }

    private static (IEnumerable<int>, IEnumerable<int>) ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in lines)
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            leftList.Add(int.Parse(split[0]));
            rightList.Add(int.Parse(split[1]));
        }

        return (leftList, rightList);
    }
}