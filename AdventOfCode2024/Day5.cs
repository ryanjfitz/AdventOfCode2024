namespace AdventOfCode2024;

public static class Day5
{
    public static bool IsUpdateInOrder(string rules, string update)
    {
        var ruleList = rules.Split('\n').Select(rule => rule.Split('|').Select(int.Parse).ToArray()).ToArray();

        var pageList = update.Split(",").Select(int.Parse).ToArray();

        foreach (var rule in ruleList)
        {
            int leftRuleIndex = Array.IndexOf(pageList, rule[0]);
            int rightRuleIndex = Array.IndexOf(pageList, rule[1]);

            if (leftRuleIndex >= 0 && rightRuleIndex >= 0 && leftRuleIndex >= rightRuleIndex)
            {
                return false;
            }
        }

        return true;
    }

    public static int SumOfMiddlePageNumbersFromCorrectlyOrderedUpdates(string rules, string updates)
    {
        var orderedUpdates = updates.Split('\n').Where(update => IsUpdateInOrder(rules, update));

        var pagesOfOrderedUpdates = orderedUpdates.Select(p => p.Split(',').Select(int.Parse).ToArray());

        return pagesOfOrderedUpdates.Sum(p => p[p.Length / 2]);
    }

    public static int SumOfMiddlePageNumbersFromCorrectedUpdates(string rules, string updates)
    {
        var ruleList = rules.Split('\n').Select(rule => rule.Split('|').Select(int.Parse).ToArray()).ToArray();

        var updateList = updates.Split("\n");

        HashSet<int[]> correctedUpdates = new HashSet<int[]>();

        foreach (string update in updateList)
        {
            var pageList = update.Split(",").Select(int.Parse).ToArray();

            for (var i = 0; i < ruleList.Length; i++)
            {
                var rule = ruleList[i];
                int leftRuleIndex = Array.IndexOf(pageList, rule[0]);
                int rightRuleIndex = Array.IndexOf(pageList, rule[1]);

                if (leftRuleIndex >= 0 && rightRuleIndex >= 0 && leftRuleIndex >= rightRuleIndex)
                {
                    int temp = pageList[leftRuleIndex];
                    pageList[leftRuleIndex] = pageList[rightRuleIndex];
                    pageList[rightRuleIndex] = temp;
                    correctedUpdates.Add(pageList);
                    i = 0;
                }
            }
        }

        return correctedUpdates.Sum(p => p[p.Length / 2]);
    }
}