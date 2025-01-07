namespace AdventOfCode2024;

public class Day11
{
    public static long[] Blink(string input)
    {
        var stones = GetStonesFromInput(input);

        Blink(stones);

        return stones.ToArray();
    }

    private static LinkedList<long> GetStonesFromInput(string input)
    {
        return new LinkedList<long>(input.Split().Select(long.Parse));
    }

    private static void Blink(LinkedList<long> stones)
    {
        for (var node = stones.Last; node != null; node = node.Previous)
        {
            long[] blinkResult = Blink(node.Value);

            node.Value = blinkResult[0];

            if (blinkResult.Length > 1)
            {
                stones.AddAfter(node, blinkResult[1]);
            }
        }
    }

    private static long[] Blink(long stone)
    {
        if (stone == 0)
        {
            return [1];
        }

        int numberOfDigits = (int)Math.Floor(Math.Log10(stone) + 1);

        if (numberOfDigits % 2 == 0)
        {
            int halfNumberOfDigits = numberOfDigits / 2;
            int divisor = (int)Math.Pow(10, halfNumberOfDigits);
            long left = stone / divisor;
            long right = stone % divisor;
            return [left, right];
        }

        return [2024 * stone];
    }

    public static long GetStoneCount(string input, int blinkCount)
    {
        var stones = GetStonesFromInput(input);

        var cache = new Dictionary<(long, int), long>();

        return stones.Sum(stone => GetStoneCount(stone, 0, blinkCount, cache));
    }

    private static long GetStoneCount(long stone, int currentBlink, int maxBlinks, Dictionary<(long, int), long> cache)
    {
        if (cache.ContainsKey((stone, currentBlink)))
        {
            return cache[(stone, currentBlink)];
        }

        if (currentBlink == maxBlinks)
        {
            return 1;
        }

        long[] nextStones = Blink(stone);

        long result = nextStones.Sum(nextStone => GetStoneCount(nextStone, currentBlink + 1, maxBlinks, cache));

        cache[(stone, currentBlink)] = result;

        return result;
    }
}