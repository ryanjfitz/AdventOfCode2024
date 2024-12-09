namespace AdventOfCode2024.Tests;

public class Day1Tests
{
    public static TheoryData<int[], int[], int> Part1Data
    {
        get
        {
            var data = new TheoryData<int[], int[], int>();
            data.Add([1, 2], [3, 4], 4);
            data.Add([2, 1], [4, 3], 4);
            data.Add([3, 4], [1, 2], 4);
            data.Add([4, 3], [2, 1], 4);
            data.Add([1, 2], [4, 3], 4);
            data.Add([2, 1], [3, 4], 4);
            data.Add([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3], 11);
            var puzzleInput = ParsePuzzleInput();
            data.Add(puzzleInput.Left, puzzleInput.Right, 2378066);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    public void Part1(int[] leftList, int[] rightList, int expectedTotalDistance)
    {
        int actualTotalDistance = Day1.GetTotalDistance(leftList, rightList);

        Assert.Equal(expectedTotalDistance, actualTotalDistance);
    }

    public static TheoryData<int[], int[], int> Part2Data
    {
        get
        {
            var data = new TheoryData<int[], int[], int>();
            data.Add([1, 2, 3], [1, 2, 3], 6);
            data.Add([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3], 31);
            var puzzleInput = ParsePuzzleInput();
            data.Add(puzzleInput.Left, puzzleInput.Right, 18934359);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    public void Part2(int[] leftList, int[] rightList, int expectedSimilarityScore)
    {
        int actualSimilarityScore = Day1.GetSimilarityScore(leftList, rightList);

        Assert.Equal(expectedSimilarityScore, actualSimilarityScore);
    }

    private static (int[] Left, int[] Right) ParsePuzzleInput()
    {
        var lines = File.ReadAllLines("Day1.txt");

        var lefts = new List<int>();
        var rights = new List<int>();

        foreach (var line in lines)
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            lefts.Add(int.Parse(split[0]));
            rights.Add(int.Parse(split[1]));
        }

        return (lefts.ToArray(), rights.ToArray());
    }
}