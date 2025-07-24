using System.Text;

namespace AdventOfCode2024;

public class Day15Part2(string input) : Day15(input)
{
    private protected override Position Move(Position position, char move)
    {
        return move switch
        {
            '^' => MoveUp(position, move),
            'v' => MoveDown(position, move),
            '<' => MoveLeft(position, move),
            '>' => MoveRight(position, move),
            _ => position
        };
    }

    private Position MoveUp(Position position, char move)
    {
        if (Grid.GetValueAt(position.Top) == '[' && Grid.GetValueAt(position.Top.Right) == ']')
        {
            if (CantMove(position.Top, move) || CantMove(position.Top.Right, move))
            {
                return position;
            }

            if (Move(position.Top, move) == position.Top)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Top.Left) == '[')
            {
                Move(position.Top.Left, move);
            }

            if (Grid.GetValueAt(position.Top.Right) == '[' || Grid.GetValueAt(position.Top.Right) == ']')
            {
                Move(position.Top.Right, move);
            }

            if (Grid.GetValueAt(position.Top.Right.Top) != '.' || Grid.GetValueAt(position.Top.Top) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Top.Top, '[');
            Grid.SetValueAt(position.Top.Right.Top, ']');
            Grid.SetValueAt(position.Top, '.');
            Grid.SetValueAt(position.Top.Right, '.');
        }

        if (Grid.GetValueAt(position.Top) == ']' && Grid.GetValueAt(position.Top.Left) == '[')
        {
            if (CantMove(position.Top, move) || CantMove(position.Top.Left, move))
            {
                return position;
            }

            if (Move(position.Top, move) == position.Top)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Top.Right) == ']')
            {
                Move(position.Top.Right, move);
            }

            if (Grid.GetValueAt(position.Top.Left) == '[' || Grid.GetValueAt(position.Top.Left) == ']')
            {
                Move(position.Top.Left, move);
            }

            if (Grid.GetValueAt(position.Top.Left.Top) != '.' || Grid.GetValueAt(position.Top.Top) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Top.Top, ']');
            Grid.SetValueAt(position.Top.Left.Top, '[');
            Grid.SetValueAt(position.Top, '.');
            Grid.SetValueAt(position.Top.Left, '.');
        }

        if (Grid.GetValueAt(position.Top) == '#')
        {
            return position;
        }

        return position.Top;
    }

    private Position MoveDown(Position position, char move)
    {
        if (Grid.GetValueAt(position.Bottom) == '[' && Grid.GetValueAt(position.Bottom.Right) == ']')
        {
            if (CantMove(position.Bottom, move) || CantMove(position.Bottom.Right, move))
            {
                return position;
            }

            if (Move(position.Bottom, move) == position.Bottom)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Bottom.Left) == '[')
            {
                Move(position.Bottom.Left, move);
            }

            if (Grid.GetValueAt(position.Bottom.Right) == '[' || Grid.GetValueAt(position.Bottom.Right) == ']')
            {
                Move(position.Bottom.Right, move);
            }

            if (Grid.GetValueAt(position.Bottom.Right.Bottom) != '.' || Grid.GetValueAt(position.Bottom.Bottom) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Bottom.Bottom, '[');
            Grid.SetValueAt(position.Bottom.Right.Bottom, ']');
            Grid.SetValueAt(position.Bottom, '.');
            Grid.SetValueAt(position.Bottom.Right, '.');
        }

        if (Grid.GetValueAt(position.Bottom) == ']' && Grid.GetValueAt(position.Bottom.Left) == '[')
        {
            if (CantMove(position.Bottom, move) || CantMove(position.Bottom.Left, move))
            {
                return position;
            }

            if (Move(position.Bottom, move) == position.Bottom)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Bottom.Right) == ']')
            {
                Move(position.Bottom.Right, move);
            }

            if (Grid.GetValueAt(position.Bottom.Left) == '[' || Grid.GetValueAt(position.Bottom.Left) == ']')
            {
                Move(position.Bottom.Left, move);
            }

            if (Grid.GetValueAt(position.Bottom.Left.Bottom) != '.' || Grid.GetValueAt(position.Bottom.Bottom) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Bottom.Bottom, ']');
            Grid.SetValueAt(position.Bottom.Left.Bottom, '[');
            Grid.SetValueAt(position.Bottom, '.');
            Grid.SetValueAt(position.Bottom.Left, '.');
        }

        if (Grid.GetValueAt(position.Bottom) == '#')
        {
            return position;
        }

        return position.Bottom;
    }

    private bool CantMove(Position position, char move)
    {
        return new Day15Part2(input)
        {
            _moves = new Queue<char>(_moves)
        }.Move(position, move) == position;
    }

    private Position MoveLeft(Position position, char move)
    {
        if (Grid.GetValueAt(position.Left) == ']' && Grid.GetValueAt(position.Left.Left) == '[')
        {
            Move(position.Left.Left, move);

            if (Grid.GetValueAt(position.Left.Left.Left) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Left, '.');
            Grid.SetValueAt(position.Left.Left, ']');
            Grid.SetValueAt(position.Left.Left.Left, '[');
        }

        if (Grid.GetValueAt(position.Left) == '#')
        {
            return position;
        }

        return position.Left;
    }

    private Position MoveRight(Position position, char move)
    {
        if (Grid.GetValueAt(position.Right) == '[' && Grid.GetValueAt(position.Right.Right) == ']')
        {
            Move(position.Right.Right, move);

            if (Grid.GetValueAt(position.Right.Right.Right) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Right, '.');
            Grid.SetValueAt(position.Right.Right, '[');
            Grid.SetValueAt(position.Right.Right.Right, ']');
        }

        if (Grid.GetValueAt(position.Right) == '#')
        {
            return position;
        }

        return position.Right;
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