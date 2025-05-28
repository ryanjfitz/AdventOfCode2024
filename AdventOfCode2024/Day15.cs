using System.Text;

namespace AdventOfCode2024;

public class Day15
{
    private readonly char[,] _grid;
    private readonly Queue<char> _moves = [];
    private Position _robotPosition = null!;

    public IReadOnlyCollection<char> Moves => _moves;

    public Day15(string input)
    {
        StringBuilder grid = new StringBuilder();

        string[] lines = input.Split(Environment.NewLine);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (line.StartsWith('#'))
            {
                for (int j = 0; j < line.Length; j++)
                {
                    grid.Append(line[j]);

                    if (line[j] == '@')
                    {
                        _robotPosition = new Position(i, j);
                    }
                }

                grid.AppendLine();
            }
            else
            {
                foreach (char c in line)
                {
                    _moves.Enqueue(c);
                }
            }
        }

        _grid = grid.ToString().TrimEnd().ToTwoDimensionalArray<char>();
    }

    public void Tick()
    {
        _grid[_robotPosition.I, _robotPosition.J] = '.';

        Move(_robotPosition, _moves.Dequeue());

        _grid[_robotPosition.I, _robotPosition.J] = '@';
    }

    private bool Move(Position position, char move)
    {
        Position next = null!;
        Position nextNext = null!;

        switch (move)
        {
            case '^':
                next = position.Top;
                nextNext = next.Top;
                break;
            case 'v':
                next = position.Bottom;
                nextNext = next.Bottom;
                break;
            case '<':
                next = position.Left;
                nextNext = next.Left;
                break;
            case '>':
                next = position.Right;
                nextNext = next.Right;
                break;
        }

        if (_grid[next.I, next.J] == '#')
        {
            return false;
        }

        if (_grid[next.I, next.J] == 'O')
        {
            if (!Move(next, move))
            {
                return false;
            }

            _grid[nextNext.I, nextNext.J] = 'O';
        }

        _robotPosition = next;
        return true;
    }

    public int GetGpsSum()
    {
        return GetGpsSum(_grid);
    }

    public static int GetGpsSum(char[,] grid)
    {
        int sum = 0;

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == 'O')
                {
                    sum += 100 * i + j;
                }
            }
        }

        return sum;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i <= _grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= _grid.GetUpperBound(1); j++)
            {
                result.Append(_grid[i, j]);
            }

            result.AppendLine();
        }

        return result.ToString().TrimEnd();
    }
}