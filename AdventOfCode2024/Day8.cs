using System.Collections.Concurrent;

namespace AdventOfCode2024;

public static class Day8
{
    public static int GetAntinodeCount(string input, bool part2 = false)
    {
        var grid = input.ToTwoDimensionalCharArray();

        var antennas = GetAntennas(grid);

        var antinodes = part2 ? GetAntinodesPart2(grid, antennas) : GetAntinodes(grid, antennas);

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

    private static IEnumerable<Position> GetAntinodes(char[,] grid, IEnumerable<Antenna> antennas)
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

                    var antinodeCandidateOne = antennaPositionOne - diff;
                    if (antinodeCandidateOne != antennaPositionOne &&
                        antinodeCandidateOne != antennaPositionTwo &&
                        antinodeCandidateOne.IsWithinBounds(grid))
                    {
                        antinodes.Add(antinodeCandidateOne);
                    }

                    var antinodeCandidateTwo = antennaPositionTwo + diff;
                    if (antinodeCandidateTwo != antennaPositionOne &&
                        antinodeCandidateTwo != antennaPositionTwo &&
                        antinodeCandidateTwo.IsWithinBounds(grid))
                    {
                        antinodes.Add(antinodeCandidateTwo);
                    }
                }
            }
        }

        return antinodes;
    }

    private record Antenna(char Frequency, IList<Position> Positions);

    private record Position(int I, int J)
    {
        public static Position operator +(Position a, Position b)
        {
            return new Position(a.I + b.I, a.J + b.J);
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(a.I - b.I, a.J - b.J);
        }

        public bool IsWithinBounds(char[,] grid)
        {
            return I >= grid.GetLowerBound(0) &&
                   J >= grid.GetLowerBound(1) &&
                   I <= grid.GetUpperBound(0) &&
                   J <= grid.GetUpperBound(1);
        }
    }

    private static IEnumerable<Position> GetAntinodesPart2(char[,] grid, IEnumerable<Antenna> antennas)
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

                    var antinodeCandidateOne = antennaPositionOne;
                    do
                    {
                        if (antinodeCandidateOne.IsWithinBounds(grid))
                        {
                            antinodes.Add(antinodeCandidateOne);
                        }

                        antinodeCandidateOne -= diff;
                    } while (antinodeCandidateOne.IsWithinBounds(grid));

                    var antinodeCandidateTwo = antennaPositionTwo;
                    do
                    {
                        if (antinodeCandidateTwo.IsWithinBounds(grid))
                        {
                            antinodes.Add(antinodeCandidateTwo);
                        }

                        antinodeCandidateTwo += diff;
                    } while (antinodeCandidateTwo.IsWithinBounds(grid));
                }
            }
        }

        return antinodes;
    }
}