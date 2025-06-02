namespace AdventOfCode2024.Tests;

public class Day9Tests
{
    private static readonly string PuzzleInput = File.ReadAllText("Day9.txt");

    public static IEnumerable<(string, string, string, long)> GetMoveBlocksAndCalculateChecksumData()
    {
        yield return ("1", "0", "0", 0);
        yield return ("11", "0.", "0.", 0);
        yield return ("111", "0.1", "01.", 1);
        yield return ("1111", "0.1.", "01..", 1);
        yield return ("11111", "0.1.2", "021..", 4);
        yield return ("12", "0..", "0..", 0);
        yield return ("123", "0..111", "0111..", 6);
        yield return ("12345", "0..111....22222", "022111222......", 60);
        yield return ("2333133121414131402", "00...111...2...333.44.5555.6666.777.888899",
            "0099811188827773336446555566..............", 1928);
        yield return ("101010101", "01234", "01234", 30);
        yield return ("101010101010101010101", "012345678910", "012345678910", 385);
    }

    [Test]
    [MethodDataSource(nameof(GetMoveBlocksAndCalculateChecksumData))]
    public async Task MoveBlocksAndCalculateChecksum(string diskMap, string expectedBlocks, string expectedMovedBlocks, long expectedChecksum)
    {
        var result = Day9.MoveBlocksAndCalculateChecksum(diskMap);

        using (Assert.Multiple())
        {
            await Assert.That(result.Blocks).IsEqualTo(expectedBlocks);
            await Assert.That(result.MovedBlocks).IsEqualTo(expectedMovedBlocks);
            await Assert.That(result.Checksum).IsEqualTo(expectedChecksum);
        }
    }

    [Test]
    public async Task Solves_part_1()
    {
        var result = Day9.MoveBlocksAndCalculateChecksum(PuzzleInput);

        await Assert.That(result.Checksum).IsEqualTo(6367087064415);
    }

    public static IEnumerable<(string, string, string, long)> GetMoveFilesAndCalculateChecksumData()
    {
        yield return ("2333133121414131402", "00...111...2...333.44.5555.6666.777.888899",
            "00992111777.44.333....5555.6666.....8888..", 2858);
    }

    [Test]
    [MethodDataSource(nameof(GetMoveFilesAndCalculateChecksumData))]
    public async Task MoveFilesAndCalculateChecksum(string diskMap, string expectedFiles, string expectedMovedFiles, long expectedChecksum)
    {
        var result = Day9.MoveFilesAndCalculateChecksum(diskMap);

        using (Assert.Multiple())
        {
            await Assert.That(result.Files).IsEqualTo(expectedFiles);
            await Assert.That(result.MovedFiles).IsEqualTo(expectedMovedFiles);
            await Assert.That(result.Checksum).IsEqualTo(expectedChecksum);
        }
    }

    [Test]
    public async Task Solves_part_2()
    {
        var result = Day9.MoveFilesAndCalculateChecksum(PuzzleInput);

        await Assert.That(result.Checksum).IsEqualTo(6390781891880);
    }
}