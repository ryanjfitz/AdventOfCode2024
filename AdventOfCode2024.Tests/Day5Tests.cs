namespace AdventOfCode2024.Tests;

public class Day5Tests
{
    public static TheoryData<string, string, bool> IsUpdateInOrderData => new()
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
        Assert.Equal(expected, Day5.IsUpdateInOrder(rules, update));
    }

    public static TheoryData<string, int> SumOfMiddlePageNumbersFromCorrectlyOrderedPagesData => new()
    {
        {
            """
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13
            53|13

            75,47,61,53,29
            97,61,53,29,13
            75,29,13
            75,97,47,61,53
            61,13,29
            97,13,75,29,47
            """,
            143
        },
        { File.ReadAllText("Day5.txt"), 6505 }
    };

    [Theory]
    [MemberData(nameof(SumOfMiddlePageNumbersFromCorrectlyOrderedPagesData))]
    public void SumOfMiddlePageNumbersFromCorrectlyOrderedPages(string input, int expected)
    {
        Assert.Equal(expected, Day5.SumOfMiddlePageNumbersFromCorrectlyOrderedUpdates(input));
    }

    public static TheoryData<string, int> SumOfMiddlePageNumbersFromCorrectedUpdatesData => new()
    {
        {
            """
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13
            53|13

            75,97,47,61,53
            """,
            47
        },
        {
            """
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13
            53|13

            61,13,29
            """,
            29
        },
        {
            """
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13
            53|13

            97,13,75,29,47
            """,
            47
        },
        { File.ReadAllText("Day5.txt"), 6897 }
    };

    [Theory]
    [MemberData(nameof(SumOfMiddlePageNumbersFromCorrectedUpdatesData))]
    public void SumOfMiddlePageNumbersFromCorrectedUpdates(string input, int expected)
    {
        Assert.Equal(expected, Day5.SumOfMiddlePageNumbersFromCorrectedUpdates(input));
    }
}