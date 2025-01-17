namespace AdventOfCode2024.Tests;

public class Day5Tests
{
    public static IEnumerable<(string, string, bool)> GetIsUpdateInOrderData()
    {
        yield return ("1|2", "1,2", true);
        yield return ("1|2", "2,1", false);
        yield return ("1|2\n2|3", "1,2,3", true);
        yield return ("1|2\n2|3", "2,1,3", false);
        yield return ("2|3\n1|2", "1,2,3", true);
        yield return ("1|2\n2|3\n3|4", "1,2,3", true);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "75,47,61,53,29", true);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "97,61,53,29,13", true);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "75,29,13", true);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "75,97,47,61,53", false);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "61,13,29", false);
        yield return (
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13",
            "97,13,75,29,47", false);
    }

    [Test]
    [MethodDataSource(nameof(GetIsUpdateInOrderData))]
    public async Task IsUpdateInOrder(string rules, string update, bool expected)
    {
        await Assert.That(Day5.IsUpdateInOrder(rules, update)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetSumOfMiddlePageNumbersFromCorrectlyOrderedPagesData()
    {
        yield return ("""
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
                      """, 143);
        yield return (File.ReadAllText("Day5.txt"), 6505);
    }

    [Test]
    [MethodDataSource(nameof(GetSumOfMiddlePageNumbersFromCorrectlyOrderedPagesData))]
    public async Task SumOfMiddlePageNumbersFromCorrectlyOrderedPages(string input, int expected)
    {
        await Assert.That(Day5.SumOfMiddlePageNumbersFromCorrectlyOrderedUpdates(input)).IsEqualTo(expected);
    }

    public static IEnumerable<(string, int)> GetSumOfMiddlePageNumbersFromCorrectedUpdatesData()
    {
        yield return ("""
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
                      """, 47);
        yield return ("""
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
                      """, 29);
        yield return ("""
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
                      """, 47);
        yield return (File.ReadAllText("Day5.txt"), 6897);
    }

    [Test]
    [MethodDataSource(nameof(GetSumOfMiddlePageNumbersFromCorrectedUpdatesData))]
    public async Task SumOfMiddlePageNumbersFromCorrectedUpdates(string input, int expected)
    {
        await Assert.That(Day5.SumOfMiddlePageNumbersFromCorrectedUpdates(input)).IsEqualTo(expected);
    }
}