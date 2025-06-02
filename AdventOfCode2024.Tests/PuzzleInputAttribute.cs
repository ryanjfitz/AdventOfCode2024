namespace AdventOfCode2024.Tests;

public class PuzzleInputAttribute : DataSourceGeneratorAttribute<string, int>
{
    private readonly string _puzzleInput;
    private readonly int _expected;

    public PuzzleInputAttribute(string fileName, int expected)
    {
        _puzzleInput = File.ReadAllText(fileName);
        _expected = expected;
    }

    public override IEnumerable<Func<(string, int)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (_puzzleInput, _expected);
    }
}