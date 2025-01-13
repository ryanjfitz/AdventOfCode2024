namespace AdventOfCode2024;

public static class Day5
{
    public static bool IsUpdateInOrder(string rules, string update)
    {
        var (parsedRules, parsedUpdates) = ParseInput(rules + Environment.NewLine + update);

        return IsUpdateInOrder(parsedRules, parsedUpdates[0]);
    }

    private static bool IsUpdateInOrder(int[][] rules, int[] update)
    {
        return CheckUpdateOrder(rules, update, () => true, (_, _) => false);
    }

    private static T CheckUpdateOrder<T>(
        int[][] rules,
        int[] update,
        Func<T> inOrderFunc,
        Func<int, int, T> outOfOrderFunc)
    {
        foreach (var rule in rules)
        {
            int leftRuleIndex = Array.IndexOf(update, rule[0]);
            int rightRuleIndex = Array.IndexOf(update, rule[1]);

            if (leftRuleIndex >= 0 && rightRuleIndex >= 0 && leftRuleIndex >= rightRuleIndex)
            {
                return outOfOrderFunc(leftRuleIndex, rightRuleIndex);
            }
        }

        return inOrderFunc();
    }

    public static int SumOfMiddlePageNumbersFromCorrectlyOrderedUpdates(string input)
    {
        var (rules, updates) = ParseInput(input);

        return updates
            .Where(update => IsUpdateInOrder(rules, update))
            .Sum(update => update[update.Length / 2]);
    }

    public static int SumOfMiddlePageNumbersFromCorrectedUpdates(string input)
    {
        var (rules, updates) = ParseInput(input);

        return updates
            .Where(update => !IsUpdateInOrder(rules, update))
            .Select(update => FixUpdateOrder(rules, update))
            .Sum(update => update[update.Length / 2]);
    }

    private static int[] FixUpdateOrder(int[][] rules, int[] update)
    {
        return CheckUpdateOrder(rules, update, () => update, (leftRuleIndex, rightRuleIndex) =>
        {
            (update[leftRuleIndex], update[rightRuleIndex]) = (update[rightRuleIndex], update[leftRuleIndex]);
            return FixUpdateOrder(rules, update);
        });
    }

    private static (int[][] Rules, int[][] Updates) ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        var rules = new List<int[]>();
        var updates = new List<int[]>();

        foreach (var line in lines)
        {
            if (line.Contains('|'))
            {
                rules.Add(line.Split('|').Select(int.Parse).ToArray());
            }
            else if (line.Contains(','))
            {
                updates.Add(line.Split(',').Select(int.Parse).ToArray());
            }
        }

        return (rules.ToArray(), updates.ToArray());
    }
}