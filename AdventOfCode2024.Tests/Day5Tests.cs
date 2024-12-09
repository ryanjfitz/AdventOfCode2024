namespace AdventOfCode2024.Tests;

public class Day5Tests
{
    public static TheoryData<string, string, bool> IsUpdateInOrderData =>
        new()
        {
            { "1|2", "1,2", true },
            { "1|2", "2,1", false },
            { "1|2\n2|3", "1,2,3", true },
            { "1|2\n2|3", "2,1,3", false },
            { "2|3\n1|2", "1,2,3", true },
            { "1|2\n2|3\n3|4", "1,2,3", true },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "75,47,61,53,29",
                true
            },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "97,61,53,29,13",
                true
            },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "75,29,13",
                true
            },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "75,97,47,61,53",
                false
            },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "61,13,29",
                false
            },
            {
                "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                "97,13,75,29,47",
                false
            }
        };

    [Theory]
    [MemberData(nameof(IsUpdateInOrderData))]
    public void IsUpdateInOrder(string rules, string update, bool expected)
    {
        bool actual = Day5.IsUpdateInOrder(rules, update);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, string, int> SumOfMiddlePageNumbersFromCorrectlyOrderedPagesData
    {
        get
        {
            var data = new TheoryData<string, string, int>
            {
                {
                    "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                    "75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47",
                    143
                }
            };

            var (rules, updates) = ParsePuzzleInput();
            data.Add(rules, updates, 6505);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(SumOfMiddlePageNumbersFromCorrectlyOrderedPagesData))]
    public void SumOfMiddlePageNumbersFromCorrectlyOrderedPages(string rules, string updates, int expected)
    {
        int actual = Day5.SumOfMiddlePageNumbersFromCorrectlyOrderedUpdates(rules, updates);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, string, int> SumOfMiddlePageNumbersFromCorrectedUpdatesData
    {
        get
        {
            var data = new TheoryData<string, string, int>
            {
                {
                    "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                    "75,97,47,61,53",
                    47
                },
                {
                    "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                    "61,13,29",
                    29
                },
                {
                    "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
                    "97,13,75,29,47",
                    47
                }
            };

            var (rules, updates) = ParsePuzzleInput();
            data.Add(rules, updates, 6897);
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(SumOfMiddlePageNumbersFromCorrectedUpdatesData))]
    public void SumOfMiddlePageNumbersFromCorrectedUpdates(string rules, string updates, int expected)
    {
        int actual = Day5.SumOfMiddlePageNumbersFromCorrectedUpdates(rules, updates);

        Assert.Equal(expected, actual);
    }

    private static (string Rules, string Updates) ParsePuzzleInput()
    {
        var lines = File.ReadAllLines("Day5.txt");

        var rules = new List<string>();
        var updates = new List<string>();

        foreach (var line in lines)
        {
            switch (line.Length)
            {
                case 0:
                    continue;
                case 5:
                    rules.Add(line);
                    break;
                default:
                    updates.Add(line);
                    break;
            }
        }

        return (string.Join(Environment.NewLine, rules), string.Join(Environment.NewLine, updates));
    }
}