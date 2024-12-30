namespace AdventOfCode2024;

public static class Day9
{
    public static (string BlockRepresentation, string MovedBlockRepresentation, long Checksum)
        MoveBlocksAndCalculateChecksum(string diskMap)
    {
        string[] blockRepresentation = GetBlockRepresentation(diskMap);
        string[] movedBlocks = MoveBlocks(blockRepresentation.ToArray());
        long checksum = CalculateChecksum(movedBlocks);

        return (string.Join("", blockRepresentation), string.Join("", movedBlocks), checksum);
    }

    private static string[] GetBlockRepresentation(string diskMap)
    {
        var result = new List<string>();

        int fileId = 0;

        for (int i = 0; i < diskMap.Length; i++)
        {
            int count = int.Parse(diskMap[i].ToString());

            if (i % 2 == 0)
            {
                result.AddRange(Enumerable.Repeat(fileId++.ToString(), count));
            }
            else
            {
                result.AddRange(Enumerable.Repeat(".", count));
            }
        }

        return result.ToArray();
    }

    private static string[] MoveBlocks(string[] blockRepresentation)
    {
        for (int i = blockRepresentation.Length - 1; i >= 0; i--)
        {
            int firstFreeSpaceIndex = Array.IndexOf(blockRepresentation, ".");

            if (firstFreeSpaceIndex > i || firstFreeSpaceIndex == -1)
            {
                break;
            }

            blockRepresentation[firstFreeSpaceIndex] = blockRepresentation[i];
            blockRepresentation[i] = ".";
        }

        return blockRepresentation;
    }

    private static long CalculateChecksum(string[] blocks)
    {
        long result = 0;

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] == ".")
            {
                continue;
            }

            result += i * long.Parse(blocks[i]);
        }

        return result;
    }

    public static (string FileRepresentation, string MovedFileRepresentation, long Checksum)
        MoveFilesAndCalculateChecksum(string diskMap)
    {
        string[][] fileRepresentation = GetFileRepresentation(diskMap);
        string[][] movedFiles = MoveFiles(fileRepresentation.Select(x => x.ToArray()).ToArray());
        long checksum = CalculateChecksum(movedFiles.SelectMany(x => x).ToArray());

        return (
            string.Join("", fileRepresentation.SelectMany(x => x)),
            string.Join("", movedFiles.SelectMany(x => x)),
            checksum
        );
    }

    private static string[][] GetFileRepresentation(string diskMap)
    {
        var result = new List<List<string>>();

        int fileId = 0;

        for (int i = 0; i < diskMap.Length; i++)
        {
            int count = int.Parse(diskMap[i].ToString());

            if (i % 2 == 0)
            {
                result.Add([..Enumerable.Repeat(fileId++.ToString(), count)]);
            }
            else if (count > 0)
            {
                result.Add([..Enumerable.Repeat(".", count)]);
            }
        }

        return result.Select(r => r.ToArray()).ToArray();
    }

    private static string[][] MoveFiles(string[][] fileRepresentation)
    {
        for (int i = fileRepresentation.Length - 1; i >= 0; i--)
        {
            var file = fileRepresentation[i];

            if (IsFreeSpace(file))
            {
                continue;
            }

            var freeSpace = fileRepresentation.FirstOrDefault(f => IsFreeSpace(f) && f.Length >= file.Length);

            if (freeSpace == null)
            {
                continue;
            }

            int freeSpaceIndex = Array.IndexOf(fileRepresentation, freeSpace);
            if (freeSpaceIndex > i)
            {
                continue;
            }

            string[] freeSpaceCopy = new string[freeSpace.Length];
            Array.Copy(freeSpace, freeSpaceCopy, freeSpace.Length);

            Array.Copy(file, freeSpace, file.Length);

            int dotIndex = Array.IndexOf(freeSpace, ".");
            var left = freeSpace.Take(dotIndex).ToArray();
            var right = freeSpace.Skip(dotIndex).ToArray();
            Array.Copy(freeSpaceCopy, file, file.Length);

            if (left.Length > 0)
            {
                var x = fileRepresentation.ToList();
                x[freeSpaceIndex] = left;
                x.Insert(freeSpaceIndex + 1, right);
                i += 1;
                fileRepresentation = x.ToArray();
            }
        }

        return fileRepresentation;
    }

    private static bool IsFreeSpace(string[] file)
    {
        return file.All(f => f == ".");
    }
}