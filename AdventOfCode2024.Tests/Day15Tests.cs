namespace AdventOfCode2024.Tests;

public class Day15Tests
{
    [Test]
    // Initial state
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #...#
        #####

        ^
        """,
        0,
        """
        #####
        #...#
        #.@.#
        #...#
        #####
        """)]
    // Move up one
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #...#
        #####

        ^
        """,
        1,
        """
        #####
        #.@.#
        #...#
        #...#
        #####
        """)]
    // Move down one
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #...#
        #####

        v
        """,
        1,
        """
        #####
        #...#
        #...#
        #.@.#
        #####
        """)]
    // Move left one
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #...#
        #####

        <
        """,
        1,
        """
        #####
        #...#
        #@..#
        #...#
        #####
        """)]
    // Move right one
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #...#
        #####

        >
        """,
        1,
        """
        #####
        #...#
        #..@#
        #...#
        #####
        """)]
    // Move up one then move right one
    [Arguments(
        """
        ####
        #..#
        #@.#
        ####

        ^>
        """,
        2,
        """
        ####
        #.@#
        #..#
        ####
        """)]
    // Move up one but don't move right one yet
    [Arguments(
        """
        ####
        #..#
        #@.#
        ####

        ^>
        """,
        1,
        """
        ####
        #@.#
        #..#
        ####
        """)]
    // Does not move up one due to wall
    [Arguments(
        """
        #####
        #.#.#
        #.@.#
        #...#
        #####

        ^
        """,
        1,
        """
        #####
        #.#.#
        #.@.#
        #...#
        #####
        """)]
    // Does not move down one due to wall
    [Arguments(
        """
        #####
        #...#
        #.@.#
        #.#.#
        #####

        v
        """,
        1,
        """
        #####
        #...#
        #.@.#
        #.#.#
        #####
        """)]
    // Does not move left one due to wall
    [Arguments(
        """
        #####
        #...#
        ##@.#
        #...#
        #####

        <
        """,
        1,
        """
        #####
        #...#
        ##@.#
        #...#
        #####
        """)]
    // Does not move right one due to wall
    [Arguments(
        """
        #####
        #...#
        #.@##
        #...#
        #####

        >
        """,
        1,
        """
        #####
        #...#
        #.@##
        #...#
        #####
        """)]
    // Pushes box up one
    [Arguments(
        """
        ###
        #.#
        #O#
        #@#
        ###

        ^
        """,
        1,
        """
        ###
        #O#
        #@#
        #.#
        ###
        """)]
    // Does not push box up one due to wall
    [Arguments(
        """
        ###
        ###
        #O#
        #@#
        ###

        ^
        """,
        1,
        """
        ###
        ###
        #O#
        #@#
        ###
        """)]
    // Pushes two boxes up one
    [Arguments(
        """
        ###
        #.#
        #O#
        #O#
        #@#
        ###

        ^
        """,
        1,
        """
        ###
        #O#
        #O#
        #@#
        #.#
        ###
        """)]
    // Pushes three boxes up one
    [Arguments(
        """
        ###
        #.#
        #O#
        #O#
        #O#
        #@#
        ###

        ^
        """,
        1,
        """
        ###
        #O#
        #O#
        #O#
        #@#
        #.#
        ###
        """)]
    // Pushes three boxes down one
    [Arguments(
        """
        ###
        #@#
        #O#
        #O#
        #O#
        #.#
        ###

        v
        """,
        1,
        """
        ###
        #.#
        #@#
        #O#
        #O#
        #O#
        ###
        """)]
    // Pushes three boxes left one
    [Arguments(
        """
        #######
        #.OOO@#
        #######

        <
        """,
        1,
        """
        #######
        #OOO@.#
        #######
        """)]
    // Pushes three boxes right one
    [Arguments(
        """
        #######
        #@OOO.#
        #######

        >
        """,
        1,
        """
        #######
        #.@OOO#
        #######
        """)]
    // Smaller example
    [Arguments(
        """
        ########
        #..O.O.#
        ##@.O..#
        #...O..#
        #.#.O..#
        #...O..#
        #......#
        ########

        <^^>>>vv<v>>v<<
        """,
        15,
        """
        ########
        #....OO#
        ##.....#
        #.....O#
        #.#O@..#
        #...O..#
        #...O..#
        ########
        """)]
    // Larger example
    [Arguments(
        """
        ##########
        #..O..O.O#
        #......O.#
        #.OO..O.O#
        #..O@..O.#
        #O#..O...#
        #O..O..O.#
        #.OO.O.OO#
        #....O...#
        ##########

        <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
        vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
        ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
        <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
        ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
        ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
        >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
        <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
        ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
        v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
        """,
        700,
        """
        ##########
        #.O.O.OOO#
        #........#
        #OO......#
        #OO@.....#
        #O#.....O#
        #O.....OO#
        #O.....OO#
        #OO....OO#
        ##########
        """)]
    public async Task Should_move_robot_in_accordance_with_instructions_and_available_space(string input, int tickCount, string expected)
    {
        var sut = new Day15(input);

        for (int i = 1; i <= tickCount; i++)
        {
            sut.Tick();
        }

        await Assert.That(sut.ToString()).IsEqualTo(expected);
    }

    [Test]
    [Arguments("""
               ########
               #...O..#
               #.....@#
               ########
               """, 104)]
    [Arguments("""
               ########
               #....OO#
               ##.....#
               #.....O#
               #.#O@..#
               #...O..#
               #...O..#
               ########
               """, 2028)]
    [Arguments("""
               ##########
               #.O.O.OOO#
               #........#
               #OO......#
               #OO@.....#
               #O#.....O#
               #O.....OO#
               #O.....OO#
               #OO....OO#
               ##########
               """, 10092)]
    public async Task Should_return_sum_of_box_GPS_coordinates(string input, int expected)
    {
        await Assert.That(Day15.GetGpsSum(input.ToTwoDimensionalArray<char>())).IsEqualTo(expected);
    }

    [Test]
    public async Task Solves_part_1()
    {
        var sut = new Day15(await File.ReadAllTextAsync("Day15.txt"));

        while (sut.Moves.Count > 0)
        {
            sut.Tick();
        }

        int sum = sut.GetGpsSum();

        await Assert.That(sum).IsEqualTo(1371036);
    }
}