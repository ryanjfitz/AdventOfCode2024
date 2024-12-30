using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode2024.Tests;

public class Day9Tests
{
    public static TheoryData<string, string, string, long> MoveBlocksAndCalculateChecksumData => new()
    {
        { "1", "0", "0", 0 },
        { "11", "0.", "0.", 0 },
        { "111", "0.1", "01.", 1 },
        { "1111", "0.1.", "01..", 1 },
        { "11111", "0.1.2", "021..", 4 },
        { "12", "0..", "0..", 0 },
        { "123", "0..111", "0111..", 6 },
        { "12345", "0..111....22222", "022111222......", 60 },
        {
            "2333133121414131402",
            "00...111...2...333.44.5555.6666.777.888899",
            "0099811188827773336446555566..............",
            1928
        },
        { "101010101", "01234", "01234", 30 },
        { "101010101010101010101", "012345678910", "012345678910", 385 },
        { File.ReadAllText("Day9.txt"), "", "", 6367087064415 }
    };

    [Theory]
    [MemberData(nameof(MoveBlocksAndCalculateChecksumData))]
    public void MoveBlocksAndCalculateChecksum(
        string diskMap,
        string expectedBlockRepresentation,
        string expectedMovedBlockRepresentation,
        long expectedChecksum)
    {
        var (blockRepresentation, movedBlockRepresentation, checksum) = Day9.MoveBlocksAndCalculateChecksum(diskMap);

        using (new AssertionScope())
        {
            if (diskMap != File.ReadAllText("Day9.txt"))
            {
                blockRepresentation.Should().Be(expectedBlockRepresentation);
                movedBlockRepresentation.Should().Be(expectedMovedBlockRepresentation);
            }

            checksum.Should().Be(expectedChecksum);
        }
    }

    public static TheoryData<string, string, string, long> MoveFilesAndCalculateChecksumData => new()
    {
        {
            "2333133121414131402",
            "00...111...2...333.44.5555.6666.777.888899",
            "00992111777.44.333....5555.6666.....8888..",
            2858
        },
        { File.ReadAllText("Day9.txt"), "", "", 6390781891880 }
    };

    [Theory]
    [MemberData(nameof(MoveFilesAndCalculateChecksumData))]
    public void MoveFilesAndCalculateChecksum(
        string diskMap,
        string expectedFileRepresentation,
        string expectedMovedFileRepresentation,
        long expectedChecksum)
    {
        var (fileRepresentation, movedFileRepresentation, checksum) = Day9.MoveFilesAndCalculateChecksum(diskMap);

        using (new AssertionScope())
        {
            if (diskMap != File.ReadAllText("Day9.txt"))
            {
                fileRepresentation.Should().Be(expectedFileRepresentation);
                movedFileRepresentation.Should().Be(expectedMovedFileRepresentation);
            }

            checksum.Should().Be(expectedChecksum);
        }
    }
}