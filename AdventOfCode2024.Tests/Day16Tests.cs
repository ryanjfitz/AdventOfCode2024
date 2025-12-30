using System.Drawing;

namespace AdventOfCode2024.Tests;

public class Day16Tests
{
    public static IEnumerable<Func<(string, Point[])>> GetData()
    {
        yield return () => ("""
                            ####
                            #SE#
                            ####
                            """, [new Point(1, 1), new Point(1, 2)]);
        yield return () => ("""
                            ####
                            #ES#
                            ####
                            """, [new Point(1, 2), new Point(1, 1)]);
        yield return () => ("""
                            #####
                            #S.E#
                            #####
                            """, [new Point(1, 1), new Point(1, 2), new Point(1, 3)]);
        yield return () => ("""
                            #####
                            #E.S#
                            #####
                            """, [new Point(1, 3), new Point(1, 2), new Point(1, 1)]);
        yield return () => ("""
                            ###
                            #S#
                            #E#
                            ###
                            """, [new Point(1, 1), new Point(2, 1)]);
        yield return () => ("""
                            ###
                            #E#
                            #S#
                            ###
                            """, [new Point(2, 1), new Point(1, 1)]);
        yield return () => ("""
                            ###
                            #S#
                            #.#
                            #E#
                            ###
                            """, [new Point(1, 1), new Point(2, 1), new Point(3, 1)]);
        yield return () => ("""
                            ###
                            #E#
                            #.#
                            #S#
                            ###
                            """, [new Point(3, 1), new Point(2, 1), new Point(1, 1)]);
        yield return () => ("""
                            #####
                            #S#E#
                            #####
                            """, []);
        yield return () => ("""
                            #####
                            #E#S#
                            #####
                            """, []);
        yield return () => ("""
                            ###
                            #S#
                            ###
                            #E#
                            ###
                            """, []);
        yield return () => ("""
                            ###
                            #E#
                            ###
                            #S#
                            ###
                            """, []);
        yield return () => ("""
                            ####
                            ##E#
                            #S.#
                            ####
                            """, [new Point(2, 1), new Point(2, 2), new Point(1, 2)]);
        yield return () => ("""
                            ####
                            #E##
                            #.S#
                            ####
                            """, [new Point(2, 2), new Point(2, 1), new Point(1, 1)]);
        yield return () => ("""
                            ####
                            #S.#
                            ##E#
                            ####
                            """, [new Point(1, 1), new Point(1, 2), new Point(2, 2)]);
        yield return () => ("""
                            ####
                            #.S#
                            #E##
                            ####
                            """, [new Point(1, 2), new Point(1, 1), new Point(2, 1)]);
        yield return () => ("""
                            #####
                            #S.##
                            ##.E#
                            #####
                            """, [new Point(1, 1), new Point(1, 2), new Point(2, 2), new Point(2, 3)]);
    }

    [Test]
    [MethodDataSource(nameof(GetData))]
    public async Task Should_return_paths_to_goal(string input, Point[] expected)
    {
        await Assert.That(Day16.GetPaths(input)).IsEquivalentTo(expected);
    }
}