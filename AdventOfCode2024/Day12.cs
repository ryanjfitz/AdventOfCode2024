namespace AdventOfCode2024;

public static class Day12
{
    public static IEnumerable<Region> GetRegions(string input)
    {
        var results = new List<Region>();

        var cache = new HashSet<Position>();

        var grid = input.ToTwoDimensionalArray<char>();

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                Position currentPosition = new Position(i, j);

                char plantType = grid[i, j];

                int area = GetArea(currentPosition, grid, plantType, cache, out var traveledPositions);

                if (area > 0)
                {
                    int perimeter = GetPerimeter(traveledPositions);
                    int sides = GetSides(traveledPositions);

                    results.Add(new Region
                    {
                        PlantType = plantType,
                        Area = area,
                        Perimeter = perimeter,
                        Price = area * perimeter,
                        Sides = sides,
                        BulkDiscountPrice = area * sides
                    });
                }
            }
        }

        return results;
    }

    private static int GetSides(HashSet<Position> positions)
    {
        var squaredPositions = new HashSet<Position>();

        foreach (var position in positions)
        {
            var newPosition = new Position(position.I * 2, position.J * 2);

            squaredPositions.Add(newPosition);
            squaredPositions.Add(newPosition.Right);
            squaredPositions.Add(newPosition.Bottom);
            squaredPositions.Add(newPosition.Bottom.Right);
        }

        return squaredPositions.Count(position => IsCorner(squaredPositions, position));
    }

    private static bool IsCorner(HashSet<Position> squaredPositions, Position position)
    {
        int neighborCount = 0;

        if (squaredPositions.Contains(position.Top.Left))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Top))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Top.Right))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Left))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Right))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Bottom.Left))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Bottom))
        {
            neighborCount++;
        }

        if (squaredPositions.Contains(position.Bottom.Right))
        {
            neighborCount++;
        }

        return neighborCount is 3 or 4 or 7;
    }

    private static int GetPerimeter(HashSet<Position> positions)
    {
        int total = 0;

        foreach (var position in positions)
        {
            int current = 4;

            if (positions.Contains(position.Top))
            {
                current--;
            }

            if (positions.Contains(position.Bottom))
            {
                current--;
            }

            if (positions.Contains(position.Left))
            {
                current--;
            }

            if (positions.Contains(position.Right))
            {
                current--;
            }

            total += current;
        }

        return total;
    }

    private static int GetArea(
        Position currentPosition,
        char[,] grid,
        char plantType,
        HashSet<Position> cache,
        out HashSet<Position> traveledPositions)
    {
        traveledPositions = [];

        if (cache.Contains(currentPosition))
        {
            traveledPositions.Add(currentPosition);
            return 0;
        }

        int result = 0;

        if (currentPosition.IsWithinBounds(grid) && grid[currentPosition.I, currentPosition.J] == plantType)
        {
            result += 1;
            traveledPositions.Add(currentPosition);
            cache.Add(currentPosition);
        }

        Position top = currentPosition.Top;
        Position bottom = currentPosition.Bottom;
        Position left = currentPosition.Left;
        Position right = currentPosition.Right;

        if (top.IsWithinBounds(grid) && grid[top.I, top.J] == plantType)
        {
            result += GetArea(top, grid, plantType, cache, out var positions);
            traveledPositions.UnionWith(positions);
        }

        if (bottom.IsWithinBounds(grid) && grid[bottom.I, bottom.J] == plantType)
        {
            result += GetArea(bottom, grid, plantType, cache, out var positions);
            traveledPositions.UnionWith(positions);
        }

        if (left.IsWithinBounds(grid) && grid[left.I, left.J] == plantType)
        {
            result += GetArea(left, grid, plantType, cache, out var positions);
            traveledPositions.UnionWith(positions);
        }

        if (right.IsWithinBounds(grid) && grid[right.I, right.J] == plantType)
        {
            result += GetArea(right, grid, plantType, cache, out var positions);
            traveledPositions.UnionWith(positions);
        }

        return result;
    }

    public static int GetPrice(string input)
    {
        return GetRegions(input).Sum(region => region.Price);
    }

    public static int GetBulkDiscountPrice(string input)
    {
        return GetRegions(input).Sum(region => region.BulkDiscountPrice);
    }
}

public record Region
{
    public char PlantType { get; init; }
    public int Area { get; init; }
    public int Perimeter { get; init; }
    public int Price { get; init; }
    public int Sides { get; init; }
    public int BulkDiscountPrice { get; init; }
}