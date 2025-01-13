namespace AdventOfCode2024;

public static class Day4
{
    private record XmasPosition(
        int XRow,
        int XColumn,
        int MRow,
        int MColumn,
        int ARow,
        int AColumn,
        int SRow,
        int SColumn);

    public static int GetXmasCount(string input)
    {
        char[,] grid = input.ToTwoDimensionalArray<char>();

        var finds = new HashSet<XmasPosition>();

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                var horizontalForwards = new XmasPosition(i, j, i, j + 1, i, j + 2, i, j + 3);
                if (Found(grid, horizontalForwards))
                {
                    finds.Add(horizontalForwards);
                }

                var horizontalBackwards = new XmasPosition(i, j + 3, i, j + 2, i, j + 1, i, j);
                if (Found(grid, horizontalBackwards))
                {
                    finds.Add(horizontalBackwards);
                }

                var diagonalTopLeftToBottomRight = new XmasPosition(i, j, i + 1, j + 1, i + 2, j + 2, i + 3, j + 3);
                if (Found(grid, diagonalTopLeftToBottomRight))
                {
                    finds.Add(diagonalTopLeftToBottomRight);
                }

                var diagonalTopRightToBottomLeft = new XmasPosition(i, j + 3, i + 1, j + 2, i + 2, j + 1, i + 3, j);
                if (Found(grid, diagonalTopRightToBottomLeft))
                {
                    finds.Add(diagonalTopRightToBottomLeft);
                }

                var diagonalBottomLeftToTopRight = new XmasPosition(i + 3, j, i + 2, j + 1, i + 1, j + 2, i, j + 3);
                if (Found(grid, diagonalBottomLeftToTopRight))
                {
                    finds.Add(diagonalBottomLeftToTopRight);
                }

                var diagonalBottomRightToTopLeft = new XmasPosition(i + 3, j + 3, i + 2, j + 2, i + 1, j + 1, i, j);
                if (Found(grid, diagonalBottomRightToTopLeft))
                {
                    finds.Add(diagonalBottomRightToTopLeft);
                }

                var verticalTopToBottom = new XmasPosition(i, j, i + 1, j, i + 2, j, i + 3, j);
                if (Found(grid, verticalTopToBottom))
                {
                    finds.Add(verticalTopToBottom);
                }

                var verticalBottomToTop = new XmasPosition(i + 3, j, i + 2, j, i + 1, j, i, j);
                if (Found(grid, verticalBottomToTop))
                {
                    finds.Add(verticalBottomToTop);
                }
            }
        }

        return finds.Count;
    }

    private static bool Found(char[,] grid, XmasPosition xmasPosition)
    {
        return xmasPosition.XRow <= grid.GetUpperBound(0) && xmasPosition.XColumn <= grid.GetUpperBound(1) &&
               grid[xmasPosition.XRow, xmasPosition.XColumn] == 'X' &&
               xmasPosition.MRow <= grid.GetUpperBound(0) && xmasPosition.MColumn <= grid.GetUpperBound(1) &&
               grid[xmasPosition.MRow, xmasPosition.MColumn] == 'M' &&
               xmasPosition.ARow <= grid.GetUpperBound(0) && xmasPosition.AColumn <= grid.GetUpperBound(1) &&
               grid[xmasPosition.ARow, xmasPosition.AColumn] == 'A' &&
               xmasPosition.SRow <= grid.GetUpperBound(0) && xmasPosition.SColumn <= grid.GetUpperBound(1) &&
               grid[xmasPosition.SRow, xmasPosition.SColumn] == 'S';
    }

    private record XShapedMasPosition(
        int M1Row,
        int M1Column,
        int S1Row,
        int S1Column,
        int ARow,
        int AColumn,
        int M2Row,
        int M2Column,
        int S2Row,
        int S2Column);

    public static int GetXShapedMasCount(string input)
    {
        char[,] grid = input.ToTwoDimensionalArray<char>();

        var finds = new HashSet<XShapedMasPosition>();

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                var position1 = new XShapedMasPosition(i, j, i, j + 2, i + 1, j + 1, i + 2, j, i + 2, j + 2);
                if (Found(grid, position1))
                {
                    finds.Add(position1);
                }

                var position2 = new XShapedMasPosition(i + 2, j, i, j, i + 1, j + 1, i + 2, j + 2, i, j + 2);
                if (Found(grid, position2))
                {
                    finds.Add(position2);
                }

                var position3 = new XShapedMasPosition(i, j + 2, i, j, i + 1, j + 1, i + 2, j + 2, i + 2, j);
                if (Found(grid, position3))
                {
                    finds.Add(position3);
                }

                var position4 = new XShapedMasPosition(i, j, i + 2, j, i + 1, j + 1, i, j + 2, i + 2, j + 2);
                if (Found(grid, position4))
                {
                    finds.Add(position4);
                }
            }
        }

        return finds.Count;
    }

    private static bool Found(char[,] grid, XShapedMasPosition xShapedMasPosition)
    {
        return xShapedMasPosition.M1Row <= grid.GetUpperBound(0) &&
               xShapedMasPosition.M1Column <= grid.GetUpperBound(1) &&
               grid[xShapedMasPosition.M1Row, xShapedMasPosition.M1Column] == 'M' &&
               xShapedMasPosition.S1Row <= grid.GetUpperBound(0) &&
               xShapedMasPosition.S1Column <= grid.GetUpperBound(1) &&
               grid[xShapedMasPosition.S1Row, xShapedMasPosition.S1Column] == 'S' &&
               xShapedMasPosition.ARow <= grid.GetUpperBound(0) &&
               xShapedMasPosition.AColumn <= grid.GetUpperBound(1) &&
               grid[xShapedMasPosition.ARow, xShapedMasPosition.AColumn] == 'A' &&
               xShapedMasPosition.M2Row <= grid.GetUpperBound(0) &&
               xShapedMasPosition.M2Column <= grid.GetUpperBound(1) &&
               grid[xShapedMasPosition.M2Row, xShapedMasPosition.M2Column] == 'M' &&
               xShapedMasPosition.S2Row <= grid.GetUpperBound(0) &&
               xShapedMasPosition.S2Column <= grid.GetUpperBound(1) &&
               grid[xShapedMasPosition.S2Row, xShapedMasPosition.S2Column] == 'S';
    }
}