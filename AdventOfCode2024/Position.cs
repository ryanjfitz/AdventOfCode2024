namespace AdventOfCode2024;

internal record Position(int I, int J)
{
    public static Position operator +(Position a, Position b)
    {
        return new Position(a.I + b.I, a.J + b.J);
    }

    public static Position operator -(Position a, Position b)
    {
        return new Position(a.I - b.I, a.J - b.J);
    }

    public Position Top => this with { I = I - 1 };
    public Position Bottom => this with { I = I + 1 };
    public Position Left => this with { J = J - 1 };
    public Position Right => this with { J = J + 1 };

    public bool IsWithinBounds<T>(T[,] grid)
    {
        return I >= grid.GetLowerBound(0) &&
               J >= grid.GetLowerBound(1) &&
               I <= grid.GetUpperBound(0) &&
               J <= grid.GetUpperBound(1);
    }

    public override string ToString()
    {
        return $"({I}, {J})";
    }
}