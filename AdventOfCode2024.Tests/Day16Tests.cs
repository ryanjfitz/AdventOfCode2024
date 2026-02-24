using System.Drawing;
using AwesomeAssertions;

namespace AdventOfCode2024.Tests;

public class Day16Tests
{
    public static IEnumerable<Func<(string, Point[])>> OnePathData()
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
        yield return () => ("""
                            #####
                            ##.S#
                            #E.##
                            #####
                            """, [new Point(1, 3), new Point(1, 2), new Point(2, 2), new Point(2, 1)]);
        yield return () => ("""
                            #####
                            #E.##
                            ##.S#
                            #####
                            """, [new Point(2, 3), new Point(2, 2), new Point(1, 2), new Point(1, 1)]);
        yield return () => ("""
                            #####
                            ##.E#
                            #S.##
                            #####
                            """, [new Point(2, 1), new Point(2, 2), new Point(1, 2), new Point(1, 3)]);
        yield return () => ("""
                            ######
                            ###E.#
                            ####.#
                            #S...#
                            ######
                            """, [new Point(3, 1), new Point(3, 2), new Point(3, 3), new Point(3, 4), new Point(2, 4), new Point(1, 4), new Point(1, 3)]);
        yield return () => ("""
                            #####
                            #S#E#
                            #...#
                            #####
                            """,
            [new Point(1, 1), new Point(2, 1), new Point(2, 2), new Point(2, 3), new Point(1, 3)]);
    }

    [Test]
    [MethodDataSource(nameof(OnePathData))]
    public void Should_return_only_path_to_goal(string input, Point[] expected)
    {
        Day16.GetPaths(input).Should().ContainSingle().Which.Should().BeEquivalentTo(expected);
    }

    [Test]
    [Arguments("""
               #####
               #S#E#
               #####
               """)]
    [Arguments("""
               #######
               #S.#.E#
               #######
               """)]
    [Arguments("""
               #####
               #E#S#
               #####
               """)]
    [Arguments("""
               ###
               #S#
               ###
               #E#
               ###
               """)]
    [Arguments("""
               ###
               #E#
               ###
               #S#
               ###
               """)]
    public void Should_return_no_paths_to_goal(string input)
    {
        Day16.GetPaths(input).Should().BeEquivalentTo(Array.Empty<Point[]>());
    }

    public static IEnumerable<Func<(string, Point[][])>> MultiplePathsData()
    {
        yield return () => ("""
                            #####
                            #...#
                            #S#E#
                            #...#
                            #####
                            """,
        [
            [new Point(2, 1), new Point(1, 1), new Point(1, 2), new Point(1, 3), new Point(2, 3)],
            [new Point(2, 1), new Point(3, 1), new Point(3, 2), new Point(3, 3), new Point(2, 3)]
        ]);
    }

    [Test]
    [MethodDataSource(nameof(MultiplePathsData))]
    public void Should_return_multiple_paths_to_goal(string input, Point[][] expected)
    {
        Day16.GetPaths(input).Should().BeEquivalentTo(expected);
    }
}