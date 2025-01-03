namespace AdventOfCode2024;

public static class Day9
{
    public static (string Blocks, string MovedBlocks, long Checksum) MoveBlocksAndCalculateChecksum(string diskMap)
    {
        var blocks = GetBlocks(diskMap);
        var movedBlocks = MoveBlocks(blocks.ToArray());
        var checksum = CalculateChecksum(movedBlocks);

        return (
            string.Concat(blocks),
            string.Concat(movedBlocks),
            checksum
        );
    }

    private static List<string> GetBlocks(string diskMap)
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

        return result;
    }

    private static string[] MoveBlocks(string[] blocks)
    {
        for (int i = blocks.Length - 1; i >= 0; i--)
        {
            int firstFreeSpaceIndex = Array.IndexOf(blocks, ".");

            if (firstFreeSpaceIndex > i || firstFreeSpaceIndex == -1)
            {
                break;
            }

            blocks[firstFreeSpaceIndex] = blocks[i];
            blocks[i] = ".";
        }

        return blocks;
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

    public static (string Files, string MovedFiles, long Checksum) MoveFilesAndCalculateChecksum(string diskMap)
    {
        var files = GetFiles(diskMap);
        var movedFiles = MoveFiles(files.Select(x => x.ToArray()).ToList());
        var checksum = CalculateChecksum(movedFiles.SelectMany(x => x).ToArray());

        return (
            string.Concat(files.SelectMany(x => x)),
            string.Concat(movedFiles.SelectMany(x => x)),
            checksum
        );
    }

    private static List<string[]> GetFiles(string diskMap)
    {
        var result = new List<string[]>();

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

        return result;
    }

    private static List<string[]> MoveFiles(List<string[]> files)
    {
        for (int i = files.Count - 1; i >= 0; i--)
        {
            string[] file = files[i];

            if (IsFreeSpace(file))
            {
                continue;
            }

            string[]? freeSpace = files.FirstOrDefault(f => IsFreeSpace(f) && f.Length >= file.Length);

            if (freeSpace == null)
            {
                continue;
            }

            int freeSpaceIndex = files.IndexOf(freeSpace);

            if (freeSpaceIndex > i)
            {
                continue;
            }

            // Swap file and free space.
            string[] temp = freeSpace.ToArray();
            Array.Copy(file, freeSpace, file.Length);
            Array.Copy(temp, file, file.Length);

            // The file is in a new spot and might now have free space at the end. Split it off if so.
            int freeSpaceWithinFileIndex = Array.IndexOf(freeSpace, ".");
            if (freeSpaceWithinFileIndex != -1)
            {
                string[] fileOnly = freeSpace.Take(freeSpaceWithinFileIndex).ToArray();
                string[] extraFreeSpace = freeSpace.Skip(freeSpaceWithinFileIndex).ToArray();
                files[freeSpaceIndex] = fileOnly;
                files.Insert(freeSpaceIndex + 1, extraFreeSpace);
                i += 1;
            }
        }

        return files;
    }

    private static bool IsFreeSpace(string[] file)
    {
        return file.All(f => f == ".");
    }
}