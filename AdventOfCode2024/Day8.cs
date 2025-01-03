using System.Collections.Concurrent;

namespace AdventOfCode2024;

public static class Day8
{
    public static int GetAntinodeCount(string input, bool part2 = false)
    {
        var grid = input.ToTwoDimensionalCharArray();

        var antennas = GetAntennas(grid);

        var antinodes = GetAntinodes(grid, antennas, part2);

        return antinodes.Count();
    }

    private static IEnumerable<Antenna> GetAntennas(char[,] grid)
    {
        ConcurrentDictionary<char, Antenna> antennas = [];

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (char.IsLetter(grid[i, j]) || char.IsDigit(grid[i, j]))
                {
                    char frequency = grid[i, j];

                    antennas.GetOrAdd(frequency, _ => new Antenna(frequency, [])).Positions.Add(new Position(i, j));
                }
            }
        }

        return antennas.Values;
    }

    private static IEnumerable<Position> GetAntinodes(char[,] grid, IEnumerable<Antenna> antennas, bool part2 = false)
    {
        HashSet<Position> antinodes = [];

        foreach (var antenna in antennas)
        {
            foreach (var antennaPositions in antenna.Positions.GetPermutations().Select(p => p.ToArray()))
            {
                for (int i = 0; i < antennaPositions.Length - 1; i++)
                {
                    Position antennaPositionOne = antennaPositions[i];
                    Position antennaPositionTwo = antennaPositions[i + 1];
                    Position diff = antennaPositionTwo - antennaPositionOne;

                    if (part2)
                    {
                        Position antinode = antennaPositionOne;
                        while (antinode.IsWithinBounds(grid))
                        {
                            antinodes.Add(antinode);

                            antinode -= diff;
                        }
                    }
                    else
                    {
                        Position antinode = antennaPositionOne - diff;
                        if (antinode.IsWithinBounds(grid))
                        {
                            antinodes.Add(antinode);
                        }
                    }
                }
            }
        }

        return antinodes;
    }

    private record Antenna(char Frequency, IList<Position> Positions);
}