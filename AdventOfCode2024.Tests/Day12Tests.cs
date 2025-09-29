using System.Text.Json;
using TUnit.Assertions.Enums;

namespace AdventOfCode2024.Tests;

public class Day12Tests
{
    public static IEnumerable<Func<(string, IEnumerable<Region>)>> GetRegionData()
    {
        yield return () => ("A",
            [new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }]);
        yield return () => ("AB", [
            new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("AA",
            [new Region { PlantType = 'A', Area = 2, Perimeter = 6, Price = 12, Sides = 4, BulkDiscountPrice = 8 }]);
        yield return () => ("ABA", [
            new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            A
                            A
                            """,
            [new Region { PlantType = 'A', Area = 2, Perimeter = 6, Price = 12, Sides = 4, BulkDiscountPrice = 8 }]);
        yield return () => ("""
                            A
                            B
                            A
                            """, [
            new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'A', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            BAB
                            AAA
                            BAB
                            """, [
            new Region { PlantType = 'A', Area = 5, Perimeter = 12, Price = 60, Sides = 12, BulkDiscountPrice = 60 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            AAB
                            AAB
                            """, [
            new Region { PlantType = 'A', Area = 4, Perimeter = 8, Price = 32, Sides = 4, BulkDiscountPrice = 16 },
            new Region { PlantType = 'B', Area = 2, Perimeter = 6, Price = 12, Sides = 4, BulkDiscountPrice = 8 }
        ]);
        yield return () => ("""
                            AAB
                            AAB
                            ABB
                            """, [
            new Region { PlantType = 'A', Area = 5, Perimeter = 10, Price = 50, Sides = 6, BulkDiscountPrice = 30 },
            new Region { PlantType = 'B', Area = 4, Perimeter = 10, Price = 40, Sides = 6, BulkDiscountPrice = 24 }
        ]);
        yield return () => ("""
                            AAAA
                            BBCD
                            BBCC
                            EEEC
                            """, [
            new Region { PlantType = 'A', Area = 4, Perimeter = 10, Price = 40, Sides = 4, BulkDiscountPrice = 16 },
            new Region { PlantType = 'B', Area = 4, Perimeter = 8, Price = 32, Sides = 4, BulkDiscountPrice = 16 },
            new Region { PlantType = 'C', Area = 4, Perimeter = 10, Price = 40, Sides = 8, BulkDiscountPrice = 32 },
            new Region { PlantType = 'D', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'E', Area = 3, Perimeter = 8, Price = 24, Sides = 4, BulkDiscountPrice = 12 }
        ]);
        yield return () => ("""
                            AA
                            AB
                            AA
                            """, [
            new Region { PlantType = 'A', Area = 5, Perimeter = 12, Price = 60, Sides = 8, BulkDiscountPrice = 40 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            AA
                            AB
                            """, [
            new Region { PlantType = 'A', Area = 3, Perimeter = 8, Price = 24, Sides = 6, BulkDiscountPrice = 18 },
            new Region { PlantType = 'B', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            AA
                            AA
                            """,
            [new Region { PlantType = 'A', Area = 4, Perimeter = 8, Price = 32, Sides = 4, BulkDiscountPrice = 16 }]);
        yield return () => ("""
                            AAA
                            ABA
                            ABA
                            ABA
                            """, [
            new Region { PlantType = 'A', Area = 9, Perimeter = 20, Price = 180, Sides = 8, BulkDiscountPrice = 72 },
            new Region { PlantType = 'B', Area = 3, Perimeter = 8, Price = 24, Sides = 4, BulkDiscountPrice = 12 }
        ]);
        yield return () => ("""
                            ABA
                            ABA
                            ABA
                            AAA
                            """, [
            new Region { PlantType = 'A', Area = 9, Perimeter = 20, Price = 180, Sides = 8, BulkDiscountPrice = 72 },
            new Region { PlantType = 'B', Area = 3, Perimeter = 8, Price = 24, Sides = 4, BulkDiscountPrice = 12 }
        ]);
        yield return () => ("""
                            AAAA
                            ABBB
                            AAAA
                            """, [
            new Region { PlantType = 'A', Area = 9, Perimeter = 20, Price = 180, Sides = 8, BulkDiscountPrice = 72 },
            new Region { PlantType = 'B', Area = 3, Perimeter = 8, Price = 24, Sides = 4, BulkDiscountPrice = 12 }
        ]);
        yield return () => ("""
                            AAAA
                            BBBA
                            AAAA
                            """, [
            new Region { PlantType = 'A', Area = 9, Perimeter = 20, Price = 180, Sides = 8, BulkDiscountPrice = 72 },
            new Region { PlantType = 'B', Area = 3, Perimeter = 8, Price = 24, Sides = 4, BulkDiscountPrice = 12 }
        ]);
        yield return () => ("""
                            OOOOO
                            OXOXO
                            OOOOO
                            OXOXO
                            OOOOO
                            """, [
            new Region { PlantType = 'O', Area = 21, Perimeter = 36, Price = 756, Sides = 20, BulkDiscountPrice = 420 },
            new Region { PlantType = 'X', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'X', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'X', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'X', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 }
        ]);
        yield return () => ("""
                            RRRRIICCFF
                            RRRRIICCCF
                            VVRRRCCFFF
                            VVRCCCJFFF
                            VVVVCJJCFE
                            VVIVCCJJEE
                            VVIIICJJEE
                            MIIIIIJJEE
                            MIIISIJEEE
                            MMMISSJEEE
                            """, [
            new Region { PlantType = 'R', Area = 12, Perimeter = 18, Price = 216, Sides = 10, BulkDiscountPrice = 120 },
            new Region { PlantType = 'I', Area = 4, Perimeter = 8, Price = 32, Sides = 4, BulkDiscountPrice = 16 },
            new Region { PlantType = 'C', Area = 14, Perimeter = 28, Price = 392, Sides = 22, BulkDiscountPrice = 308 },
            new Region { PlantType = 'F', Area = 10, Perimeter = 18, Price = 180, Sides = 12, BulkDiscountPrice = 120 },
            new Region { PlantType = 'V', Area = 13, Perimeter = 20, Price = 260, Sides = 10, BulkDiscountPrice = 130 },
            new Region { PlantType = 'J', Area = 11, Perimeter = 20, Price = 220, Sides = 12, BulkDiscountPrice = 132 },
            new Region { PlantType = 'C', Area = 1, Perimeter = 4, Price = 4, Sides = 4, BulkDiscountPrice = 4 },
            new Region { PlantType = 'E', Area = 13, Perimeter = 18, Price = 234, Sides = 8, BulkDiscountPrice = 104 },
            new Region { PlantType = 'I', Area = 14, Perimeter = 22, Price = 308, Sides = 16, BulkDiscountPrice = 224 },
            new Region { PlantType = 'M', Area = 5, Perimeter = 12, Price = 60, Sides = 6, BulkDiscountPrice = 30 },
            new Region { PlantType = 'S', Area = 3, Perimeter = 8, Price = 24, Sides = 6, BulkDiscountPrice = 18 }
        ]);
    }

    [Test]
    [MethodDataSource(nameof(GetRegionData))]
    public async Task GetRegions(string input, IEnumerable<Region> expected)
    {
        await Assert.That(Day12.GetRegions(input)).IsEquivalentTo(expected, CollectionOrdering.Any);
    }

    [Test]
    [Arguments("""
               RRRRIICCFF
               RRRRIICCCF
               VVRRRCCFFF
               VVRCCCJFFF
               VVVVCJJCFE
               VVIVCCJJEE
               VVIIICJJEE
               MIIIIIJJEE
               MIIISIJEEE
               MMMISSJEEE
               """, 1930)]
    [PuzzleInput("Day12.txt", 1549354)]
    public async Task GetPrice(string input, int expected)
    {
        await Assert.That(Day12.GetPrice(input)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("""
               AAAA
               BBCD
               BBCC
               EEEC
               """, 80)]
    [Arguments("""
               OOOOO
               OXOXO
               OOOOO
               OXOXO
               OOOOO
               """, 436)]
    [Arguments("""
               EEEEE
               EXXXX
               EEEEE
               EXXXX
               EEEEE
               """, 236)]
    [Arguments("""
               AAAAAA
               AAABBA
               AAABBA
               ABBAAA
               ABBAAA
               AAAAAA
               """, 368)]
    [Arguments("""
               RRRRIICCFF
               RRRRIICCCF
               VVRRRCCFFF
               VVRCCCJFFF
               VVVVCJJCFE
               VVIVCCJJEE
               VVIIICJJEE
               MIIIIIJJEE
               MIIISIJEEE
               MMMISSJEEE
               """, 1206)]
    [PuzzleInput("Day12.txt", 937032)]
    public async Task GetBulkDiscountPrice(string input, int expected)
    {
        await Assert.That(Day12.GetBulkDiscountPrice(input)).IsEqualTo(expected);
    }
}