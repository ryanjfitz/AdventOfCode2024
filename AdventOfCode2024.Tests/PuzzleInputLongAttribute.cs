namespace AdventOfCode2024.Tests;

public class PuzzleInputLongAttribute : DataSourceGeneratorAttribute<string, long>
{
    private readonly string _puzzleInput;
    private readonly long _expected;

    public PuzzleInputLongAttribute(string fileName, long expected)
    {
        _puzzleInput = File.ReadAllText(fileName);
        _expected = expected;
    }

    protected override IEnumerable<Func<(string, long)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (_puzzleInput, _expected);
    }
}