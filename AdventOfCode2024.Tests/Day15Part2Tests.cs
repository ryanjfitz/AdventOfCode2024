namespace AdventOfCode2024.Tests;

public class Day15Part2Tests
{
    [Test]
    public async Task Should_expand_input_to_wider_input()
    {
        const string input = """
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
                             """;

        const string expected = """
                                ####################
                                ##....[]....[]..[]##
                                ##............[]..##
                                ##..[][]....[]..[]##
                                ##....[]@.....[]..##
                                ##[]##....[]......##
                                ##[]....[]....[]..##
                                ##..[][]..[]..[][]##
                                ##........[]......##
                                ####################

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
                                """;

        string actual = Day15.WidenInput2X(input);

        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    // Initial state
    [Arguments(
        """
        ######
        ##..##
        ##[]##
        ##@.##
        ######

        ^
        """,
        0,
        """
        ######
        ##..##
        ##[]##
        ##@.##
        ######
        """)]
    // Pushes box up one from left side
    [Arguments(
        """
        ######
        ##..##
        ##[]##
        ##@.##
        ######

        ^
        """,
        1,
        """
        ######
        ##[]##
        ##@.##
        ##..##
        ######
        """)]
    // Pushes box up one from right side
    [Arguments(
        """
        ######
        ##..##
        ##[]##
        ##.@##
        ######

        ^
        """,
        1,
        """
        ######
        ##[]##
        ##.@##
        ##..##
        ######
        """)]
    // Pushes box down one from left side
    [Arguments(
        """
        ######
        ##@.##
        ##[]##
        ##..##
        ######

        v
        """,
        1,
        """
        ######
        ##..##
        ##@.##
        ##[]##
        ######
        """)]
    // Pushes box down one from right side
    [Arguments(
        """
        ######
        ##.@##
        ##[]##
        ##..##
        ######

        v
        """,
        1,
        """
        ######
        ##..##
        ##.@##
        ##[]##
        ######
        """)]
    // Pushes box right one
    [Arguments(
        """
        ##########
        ##.@[]..##
        ##########

        >
        """,
        1,
        """
        ##########
        ##..@[].##
        ##########
        """)]
    // Pushes box left one
    [Arguments(
        """
        ##########
        ##..[]@.##
        ##########

        <
        """,
        1,
        """
        ##########
        ##.[]@..##
        ##########
        """)]
    // Pushes two boxes up one from left side
    [Arguments(
        """
        ######
        ##..##
        ##[]##
        ##[]##
        ##@.##
        ######

        ^
        """,
        1,
        """
        ######
        ##[]##
        ##[]##
        ##@.##
        ##..##
        ######
        """)]
    // Pushes two boxes up one from right side
    [Arguments(
        """
        ######
        ##..##
        ##[]##
        ##[]##
        ##.@##
        ######

        ^
        """,
        1,
        """
        ######
        ##[]##
        ##[]##
        ##.@##
        ##..##
        ######
        """)]
    // Pushes two boxes right one
    [Arguments(
        """
        ############
        ##.@[][]..##
        ############

        >
        """,
        1,
        """
        ############
        ##..@[][].##
        ############
        """)]
    // Pushes two diagonal (/) boxes up one - robot on left
    [Arguments(
        """
        ########
        ##....##
        ##..[]##
        ##.[].##
        ##.@..##
        ########

        ^
        """,
        1,
        """
        ########
        ##..[]##
        ##.[].##
        ##.@..##
        ##....##
        ########
        """)]
    // Pushes two diagonal (/) boxes up one - robot on right
    [Arguments(
        """
        ########
        ##....##
        ##..[]##
        ##.[].##
        ##..@.##
        ########

        ^
        """,
        1,
        """
        ########
        ##..[]##
        ##.[].##
        ##..@.##
        ##....##
        ########
        """)]
    // Pushes two diagonal (\) boxes up one - robot on left
    [Arguments(
        """
        ########
        ##....##
        ##[]..##
        ##.[].##
        ##.@..##
        ########

        ^
        """,
        1,
        """
        ########
        ##[]..##
        ##.[].##
        ##.@..##
        ##....##
        ########
        """)]
    // Pushes two diagonal (\) boxes up one - robot on right
    [Arguments(
        """
        ########
        ##....##
        ##[]..##
        ##.[].##
        ##..@.##
        ########

        ^
        """,
        1,
        """
        ########
        ##[]..##
        ##.[].##
        ##..@.##
        ##....##
        ########
        """)]
    // Pushes a triangle of boxes up one - robot on right
    [Arguments(
        """
        ##############
        ##..........##
        ##..........##
        ##...[][]...##
        ##....[]....##
        ##.....@....##
        ##############

        ^
        """,
        1,
        """
        ##############
        ##..........##
        ##...[][]...##
        ##....[]....##
        ##.....@....##
        ##..........##
        ##############
        """)]
    public async Task Should_move_robot_in_accordance_with_instructions_and_available_space(string input, int tickCount, string expected)
    {
        var sut = new Day15Part2(input);

        for (int i = 1; i <= tickCount; i++)
        {
            sut.Tick();
        }

        await Assert.That(sut.ToString()).IsEqualTo(expected);
    }
}