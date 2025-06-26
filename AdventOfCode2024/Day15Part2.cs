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

        if (_grid.GetValueAt(_robotPosition.Top) == '[' && _grid.GetValueAt(_robotPosition.Top.Right) == ']')
        {
            // This is the same as the outer If but with .Top added.
            if (_grid.GetValueAt(_robotPosition.Top.Top) == '[' && _grid.GetValueAt(_robotPosition.Top.Top.Right) == ']')
            {
                _grid.SetValueAt(_robotPosition.Top.Top.Right, '.');
                _grid.SetValueAt(_robotPosition.Top.Top.Top, '[');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Right, ']');
            }

            if (_grid.GetValueAt(_robotPosition.Top.Top.Left) == '[' && _grid.GetValueAt(_robotPosition.Top.Top) == ']')
            {
                _grid.SetValueAt(_robotPosition.Top.Top.Left, '.');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Left, '[');
                _grid.SetValueAt(_robotPosition.Top.Top.Top, ']');
            }

            // This is the same as the outer If but with .Top.Right added.
            if (_grid.GetValueAt(_robotPosition.Top.Right.Top) == '[' && _grid.GetValueAt(_robotPosition.Top.Right.Top.Right) == ']')
            {
                _grid.SetValueAt(_robotPosition.Top.Right.Top.Right, '.');
                _grid.SetValueAt(_robotPosition.Top.Right.Top.Top, '[');
                _grid.SetValueAt(_robotPosition.Top.Right.Top.Top.Right, ']');
            }

            _grid.SetValueAt(_robotPosition.Top.Right, '.');
            _grid.SetValueAt(_robotPosition.Top.Top, '[');
            _grid.SetValueAt(_robotPosition.Top.Top.Right, ']');
            _robotPosition = _robotPosition.Top;
        }

        if (_grid.GetValueAt(_robotPosition.Top) == ']' && _grid.GetValueAt(_robotPosition.Top.Left) == '[')
        {
            // This is the same as the outer If but with .Top added.
            if (_grid.GetValueAt(_robotPosition.Top.Top) == ']' && _grid.GetValueAt(_robotPosition.Top.Top.Left) == '[')
            {
                _grid.SetValueAt(_robotPosition.Top.Top.Left, '.');
                _grid.SetValueAt(_robotPosition.Top.Top.Top, ']');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Left, '[');
            }

            // Kind of the mirror opposite of the above If?
            if (_grid.GetValueAt(_robotPosition.Top.Top.Right) == ']' && _grid.GetValueAt(_robotPosition.Top.Top) == '[')
            {
                _grid.SetValueAt(_robotPosition.Top.Top.Right, '.');
                _grid.SetValueAt(_robotPosition.Top.Top.Top, '[');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Right, ']');
            }

            if (_grid.GetValueAt(_robotPosition.Top.Top.Left.Left) == '[' && _grid.GetValueAt(_robotPosition.Top.Top.Left) == ']')
            {
                _grid.SetValueAt(_robotPosition.Top.Top.Left.Left, '.');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Left.Left, '[');
                _grid.SetValueAt(_robotPosition.Top.Top.Top.Left, ']');
            }

            _grid.SetValueAt(_robotPosition.Top.Left, '.');
            _grid.SetValueAt(_robotPosition.Top.Top, ']');
            _grid.SetValueAt(_robotPosition.Top.Top.Left, '[');
            _robotPosition = _robotPosition.Top;
        }

        if (_grid.GetValueAt(_robotPosition.Bottom) == '[' && _grid.GetValueAt(_robotPosition.Bottom.Right) == ']')
        {
            _grid.SetValueAt(_robotPosition.Bottom.Right, '.');
            _grid.SetValueAt(_robotPosition.Bottom.Bottom, '[');
            _grid.SetValueAt(_robotPosition.Bottom.Bottom.Right, ']');
            _robotPosition = _robotPosition.Bottom;
        }

        if (_grid.GetValueAt(_robotPosition.Bottom) == ']' && _grid.GetValueAt(_robotPosition.Bottom.Left) == '[')
        {
            _grid.SetValueAt(_robotPosition.Bottom.Left, '.');
            _grid.SetValueAt(_robotPosition.Bottom.Bottom, ']');
            _grid.SetValueAt(_robotPosition.Bottom.Bottom.Left, '[');
            _robotPosition = _robotPosition.Bottom;
        }

        if (_grid.GetValueAt(_robotPosition.Right) == '[' && _grid.GetValueAt(_robotPosition.Right.Right) == ']')
        {
            // This is the same as the outer If but with .Right.Right added.
            if (_grid.GetValueAt(_robotPosition.Right.Right.Right) == '[' &&
                _grid.GetValueAt(_robotPosition.Right.Right.Right.Right) == ']')
            {
                _grid.SetValueAt(_robotPosition.Right.Right.Right.Right, '[');
                _grid.SetValueAt(_robotPosition.Right.Right.Right.Right.Right, ']');
            }

            _grid.SetValueAt(_robotPosition.Right.Right, '[');
            _grid.SetValueAt(_robotPosition.Right.Right.Right, ']');
            _robotPosition = _robotPosition.Right;
        }

        if (_grid.GetValueAt(_robotPosition.Left) == ']' && _grid.GetValueAt(_robotPosition.Left.Left) == '[')
        {
            _grid.SetValueAt(_robotPosition.Left.Left.Left, '[');
            _grid.SetValueAt(_robotPosition.Left.Left, ']');
            _robotPosition = _robotPosition.Left;
        }

        _grid.SetValueAt(_robotPosition, '@');
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