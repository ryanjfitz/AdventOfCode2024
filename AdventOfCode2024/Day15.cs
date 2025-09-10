using System.Text;

namespace AdventOfCode2024;

public class Day15
{
    private protected readonly char[,] Grid;
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

        Grid = grid.ToString().TrimEnd().ToTwoDimensionalArray<char>();
    }

    public void Tick(char? move = null)
    {
        Grid.SetValueAt(_robotPosition, '.');

        _robotPosition = Move(_robotPosition, move ?? _moves.Dequeue());

        Grid.SetValueAt(_robotPosition, '@');
    }

    private protected virtual Position Move(Position position, char move)
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

        if (Grid.GetValueAt(next) == '#')
        {
            return position;
        }

        if (Grid.GetValueAt(next) == 'O')
        {
            if (Move(next, move) == next)
            {
                return position;
            }

            Grid.SetValueAt(nextNext, 'O');
        }

        return next;
    }

    public int GetGpsSum()
    {
        return GetGpsSum(Grid);
    }

    public static int GetGpsSum(char[,] grid)
    {
        int sum = 0;

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] == 'O' || grid[i, j] == '[')
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

        for (int i = 0; i <= Grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Grid.GetUpperBound(1); j++)
            {
                result.Append(Grid[i, j]);
            }

            result.AppendLine();
        }

        return result.ToString().TrimEnd();
    }
}