using System.Text;

namespace AdventOfCode2024;

public class Day15Part2
{
    private readonly char[,] _grid;
    private readonly Queue<char> _moves = [];
    private Position _robotPosition = null!;

    public IReadOnlyCollection<char> Moves => _moves;

    public Day15Part2(string input)
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
        _grid.SetValueAt(_robotPosition, '.');

        _robotPosition = Move(_robotPosition);

        _grid.SetValueAt(_robotPosition, '@');
    }

    private Position Move(Position position)
    {
        if (_grid.GetValueAt(position.Top) == '[' && _grid.GetValueAt(position.Top.Right) == ']')
        {
            // This is the same as the outer If but with .Top added.
            if (_grid.GetValueAt(position.Top.Top) == '[' && _grid.GetValueAt(position.Top.Right.Top) == ']')
            {
                _grid.SetValueAt(position.Top.Right.Top, '.');
                _grid.SetValueAt(position.Top.Top.Top, '[');
                _grid.SetValueAt(position.Top.Top.Right.Top, ']');
            }

            // This is the same as the outer If but with .Top.Left added.
            if (_grid.GetValueAt(position.Top.Top.Left) == '[' && _grid.GetValueAt(position.Top.Right.Top.Left) == ']')
            {
                _grid.SetValueAt(position.Top.Top.Left, '.');
                _grid.SetValueAt(position.Top.Top.Left.Top, '[');
                _grid.SetValueAt(position.Top.Right.Top.Left.Top, ']');
            }

            // This is the same as the outer If but with .Top.Right added.
            if (_grid.GetValueAt(position.Top.Right.Top) == '[' && _grid.GetValueAt(position.Top.Right.Top.Right) == ']')
            {
                _grid.SetValueAt(position.Top.Right.Top.Right, '.');
                _grid.SetValueAt(position.Top.Right.Top.Top, '[');
                _grid.SetValueAt(position.Top.Right.Top.Right.Top, ']');
            }

            _grid.SetValueAt(position.Top.Right, '.'); // originally ]
            _grid.SetValueAt(position.Top.Top, '['); // originally [ + .Top
            _grid.SetValueAt(position.Top.Right.Top, ']'); // originally ] + .Top
            position = position.Top;
        }

        if (_grid.GetValueAt(position.Top) == ']' && _grid.GetValueAt(position.Top.Left) == '[')
        {
            // This is the same as the outer If but with .Top added.
            if (_grid.GetValueAt(position.Top.Top) == ']' && _grid.GetValueAt(position.Top.Left.Top) == '[')
            {
                _grid.SetValueAt(position.Top.Top.Left, '.');
                _grid.SetValueAt(position.Top.Top.Top, ']');
                _grid.SetValueAt(position.Top.Top.Top.Left, '[');
            }

            // This is the same as the outer If but with .Top.Right added.
            if (_grid.GetValueAt(position.Top.Top.Right) == ']' && _grid.GetValueAt(position.Top.Left.Top.Right) == '[')
            {
                _grid.SetValueAt(position.Top.Top.Right, '.');
                _grid.SetValueAt(position.Top.Top.Top, '[');
                _grid.SetValueAt(position.Top.Top.Top.Right, ']');
            }

            // This is the same as the outer If but with .Top.Left added.
            if (_grid.GetValueAt(position.Top.Top.Left) == ']' && _grid.GetValueAt(position.Top.Left.Top.Left) == '[')
            {
                _grid.SetValueAt(position.Top.Top.Left.Left, '.');
                _grid.SetValueAt(position.Top.Top.Top.Left.Left, '[');
                _grid.SetValueAt(position.Top.Top.Top.Left, ']');
            }

            _grid.SetValueAt(position.Top.Left, '.'); // originally [
            _grid.SetValueAt(position.Top.Top, ']'); // originally ] + .Top
            _grid.SetValueAt(position.Top.Left.Top, '['); // originally [ + .Top
            position = position.Top;
        }

        if (_grid.GetValueAt(position.Bottom) == '[' && _grid.GetValueAt(position.Bottom.Right) == ']')
        {
            _grid.SetValueAt(position.Bottom.Right, '.'); // originally ]
            _grid.SetValueAt(position.Bottom.Bottom, '['); // originally [ + .Bottom
            _grid.SetValueAt(position.Bottom.Right.Bottom, ']'); // originally ] + .Bottom
            position = position.Bottom;
        }

        if (_grid.GetValueAt(position.Bottom) == ']' && _grid.GetValueAt(position.Bottom.Left) == '[')
        {
            _grid.SetValueAt(position.Bottom.Left, '.'); // originally [
            _grid.SetValueAt(position.Bottom.Bottom, ']'); // originally ] + .Bottom
            _grid.SetValueAt(position.Bottom.Left.Bottom, '['); // originally [ + .Bottom
            position = position.Bottom;
        }

        if (_grid.GetValueAt(position.Right) == '[' && _grid.GetValueAt(position.Right.Right) == ']')
        {
            // This is the same as the outer If but with .Right.Right added.
            if (_grid.GetValueAt(position.Right.Right.Right) == '[' &&
                _grid.GetValueAt(position.Right.Right.Right.Right) == ']')
            {
                _grid.SetValueAt(position.Right.Right.Right.Right, '[');
                _grid.SetValueAt(position.Right.Right.Right.Right.Right, ']');
            }

            _grid.SetValueAt(position.Right.Right, '[');
            _grid.SetValueAt(position.Right.Right.Right, ']');
            position = position.Right;
        }

        if (_grid.GetValueAt(position.Left) == ']' && _grid.GetValueAt(position.Left.Left) == '[')
        {
            _grid.SetValueAt(position.Left.Left.Left, '[');
            _grid.SetValueAt(position.Left.Left, ']');
            position = position.Left;
        }

        return position;
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

    public static string WidenInput2X(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (c == '#')
            {
                result.Append("##");
            }
            else if (c == 'O')
            {
                result.Append("[]");
            }
            else if (c == '.')
            {
                result.Append("..");
            }
            else if (c == '@')
            {
                result.Append("@.");
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}