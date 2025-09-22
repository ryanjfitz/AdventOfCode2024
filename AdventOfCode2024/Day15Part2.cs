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
        if (Grid.GetValueAt(position.Top) == '[')
        {
            Position top = position.Top;

            if (Grid.GetValueAt(top.Top) == ']' && Grid.GetValueAt(top.Top.Right) == '#')
            {
                return position;
            }

            while (Grid.GetValueAt(top.Top) == ']' && Grid.GetValueAt(top.Top.Right) == '[')
            {
                if (Grid.GetValueAt(top.Top.Top.Left) == '#')
                {
                    return position;
                }

                if (Grid.GetValueAt(top.Top.Top.Right.Right) == '#')
                {
                    return position;
                }

                top = top.Top;
            }

            if (Move(position.Top, move) == position.Top)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Top.Left) == '[')
            {
                Move(position.Top.Left, move);
            }

            Move(position.Top.Right, move);

            if (Grid.GetValueAt(position.Top.Right.Top) != '.' || Grid.GetValueAt(position.Top.Top) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Top.Top, '[');
            Grid.SetValueAt(position.Top.Right.Top, ']');
            Grid.SetValueAt(position.Top, '.');
            Grid.SetValueAt(position.Top.Right, '.');
        }

        if (Grid.GetValueAt(position.Top) == ']')
        {
            Position top = position.Top;

            if (Grid.GetValueAt(top.Top) == '[' && Grid.GetValueAt(top.Top.Left) == '#')
            {
                return position;
            }

            while (Grid.GetValueAt(top.Top) == '[' && Grid.GetValueAt(top.Top.Left) == ']')
            {
                if (Grid.GetValueAt(top.Top.Top.Right) == '#')
                {
                    return position;
                }

                if (Grid.GetValueAt(top.Top.Top.Left.Left) == '#')
                {
                    return position;
                }

                top = top.Top;
            }

            if (Move(position.Top, move) == position.Top)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Top.Right) == ']')
            {
                Move(position.Top.Right, move);
            }

            Move(position.Top.Left, move);

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
        if (Grid.GetValueAt(position.Bottom) == '[')
        {
            Position bottom = position.Bottom;

            if (Grid.GetValueAt(bottom.Bottom) == ']' && Grid.GetValueAt(bottom.Bottom.Right) == '#')
            {
                return position;
            }

            while (Grid.GetValueAt(bottom.Bottom) == ']' && Grid.GetValueAt(bottom.Bottom.Right) == '[')
            {
                if (Grid.GetValueAt(bottom.Bottom.Bottom.Left) == '#')
                {
                    return position;
                }

                if (Grid.GetValueAt(bottom.Bottom.Bottom.Right.Right) == '#')
                {
                    return position;
                }

                bottom = bottom.Bottom;
            }

            if (Move(position.Bottom, move) == position.Bottom)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Bottom.Left) == '[')
            {
                Move(position.Bottom.Left, move);
            }

            Move(position.Bottom.Right, move);

            if (Grid.GetValueAt(position.Bottom.Right.Bottom) != '.' || Grid.GetValueAt(position.Bottom.Bottom) != '.')
            {
                return position;
            }

            Grid.SetValueAt(position.Bottom.Bottom, '[');
            Grid.SetValueAt(position.Bottom.Right.Bottom, ']');
            Grid.SetValueAt(position.Bottom, '.');
            Grid.SetValueAt(position.Bottom.Right, '.');
        }

        if (Grid.GetValueAt(position.Bottom) == ']')
        {
            Position bottom = position.Bottom;

            if (Grid.GetValueAt(bottom.Bottom) == '[' && Grid.GetValueAt(bottom.Bottom.Left) == '#')
            {
                return position;
            }

            while (Grid.GetValueAt(bottom.Bottom) == '[' && Grid.GetValueAt(bottom.Bottom.Left) == ']')
            {
                if (Grid.GetValueAt(bottom.Bottom.Bottom.Right) == '#')
                {
                    return position;
                }

                if (Grid.GetValueAt(bottom.Bottom.Bottom.Left.Left) == '#')
                {
                    return position;
                }

                bottom = bottom.Bottom;
            }

            if (Move(position.Bottom, move) == position.Bottom)
            {
                return position;
            }

            if (Grid.GetValueAt(position.Bottom.Right) == ']')
            {
                Move(position.Bottom.Right, move);
            }

            Move(position.Bottom.Left, move);

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

    private Position MoveLeft(Position position, char move)
    {
        if (Grid.GetValueAt(position.Left) == ']')
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
        if (Grid.GetValueAt(position.Right) == '[')
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