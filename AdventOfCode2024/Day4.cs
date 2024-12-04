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

    public static int GetXmasCount(char[,] input)
    {
        if (input.GetLength(0) != input.GetLength(1))
        {
            throw new ArgumentException("Input must be a two-dimensional square array.");
        }

        var finds = new HashSet<XmasPosition>();

        for (var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                var horizontalForwards = new XmasPosition(i, j, i, j + 1, i, j + 2, i, j + 3);
                if (Found(input, horizontalForwards))
                {
                    finds.Add(horizontalForwards);
                }

                var horizontalBackwards = new XmasPosition(i, j + 3, i, j + 2, i, j + 1, i, j);
                if (Found(input, horizontalBackwards))
                {
                    finds.Add(horizontalBackwards);
                }

                var diagonalTopLeftToBottomRight = new XmasPosition(i, j, i + 1, j + 1, i + 2, j + 2, i + 3, j + 3);
                if (Found(input, diagonalTopLeftToBottomRight))
                {
                    finds.Add(diagonalTopLeftToBottomRight);
                }

                var diagonalTopRightToBottomLeft = new XmasPosition(i, j + 3, i + 1, j + 2, i + 2, j + 1, i + 3, j);
                if (Found(input, diagonalTopRightToBottomLeft))
                {
                    finds.Add(diagonalTopRightToBottomLeft);
                }

                var diagonalBottomLeftToTopRight = new XmasPosition(i + 3, j, i + 2, j + 1, i + 1, j + 2, i, j + 3);
                if (Found(input, diagonalBottomLeftToTopRight))
                {
                    finds.Add(diagonalBottomLeftToTopRight);
                }

                var diagonalBottomRightToTopLeft = new XmasPosition(i + 3, j + 3, i + 2, j + 2, i + 1, j + 1, i, j);
                if (Found(input, diagonalBottomRightToTopLeft))
                {
                    finds.Add(diagonalBottomRightToTopLeft);
                }

                var verticalTopToBottom = new XmasPosition(i, j, i + 1, j, i + 2, j, i + 3, j);
                if (Found(input, verticalTopToBottom))
                {
                    finds.Add(verticalTopToBottom);
                }

                var verticalBottomToTop = new XmasPosition(i + 3, j, i + 2, j, i + 1, j, i, j);
                if (Found(input, verticalBottomToTop))
                {
                    finds.Add(verticalBottomToTop);
                }
            }
        }

        return finds.Count;
    }

    private static bool Found(char[,] input, XmasPosition xmasPosition)
    {
        return xmasPosition.XRow <= input.GetUpperBound(0) && xmasPosition.XColumn <= input.GetUpperBound(1) &&
               input[xmasPosition.XRow, xmasPosition.XColumn] == 'X' &&
               xmasPosition.MRow <= input.GetUpperBound(0) && xmasPosition.MColumn <= input.GetUpperBound(1) &&
               input[xmasPosition.MRow, xmasPosition.MColumn] == 'M' &&
               xmasPosition.ARow <= input.GetUpperBound(0) && xmasPosition.AColumn <= input.GetUpperBound(1) &&
               input[xmasPosition.ARow, xmasPosition.AColumn] == 'A' &&
               xmasPosition.SRow <= input.GetUpperBound(0) && xmasPosition.SColumn <= input.GetUpperBound(1) &&
               input[xmasPosition.SRow, xmasPosition.SColumn] == 'S';
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

    public static int GetXShapedMasCount(char[,] input)
    {
        if (input.GetLength(0) != input.GetLength(1))
        {
            throw new ArgumentException("Input must be a two-dimensional square array.");
        }

        var finds = new HashSet<XShapedMasPosition>();

        for (var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                var position1 = new XShapedMasPosition(i, j, i, j + 2, i + 1, j + 1, i + 2, j, i + 2, j + 2);
                if (Found(input, position1))
                {
                    finds.Add(position1);
                }

                var position2 = new XShapedMasPosition(i + 2, j, i, j, i + 1, j + 1, i + 2, j + 2, i, j + 2);
                if (Found(input, position2))
                {
                    finds.Add(position2);
                }

                var position3 = new XShapedMasPosition(i, j + 2, i, j, i + 1, j + 1, i + 2, j + 2, i + 2, j);
                if (Found(input, position3))
                {
                    finds.Add(position3);
                }

                var position4 = new XShapedMasPosition(i, j, i + 2, j, i + 1, j + 1, i, j + 2, i + 2, j + 2);
                if (Found(input, position4))
                {
                    finds.Add(position4);
                }
            }
        }

        return finds.Count;
    }

    private static bool Found(char[,] input, XShapedMasPosition xShapedMasPosition)
    {
        return xShapedMasPosition.M1Row <= input.GetUpperBound(0) &&
               xShapedMasPosition.M1Column <= input.GetUpperBound(1) &&
               input[xShapedMasPosition.M1Row, xShapedMasPosition.M1Column] == 'M' &&
               xShapedMasPosition.S1Row <= input.GetUpperBound(0) &&
               xShapedMasPosition.S1Column <= input.GetUpperBound(1) &&
               input[xShapedMasPosition.S1Row, xShapedMasPosition.S1Column] == 'S' &&
               xShapedMasPosition.ARow <= input.GetUpperBound(0) &&
               xShapedMasPosition.AColumn <= input.GetUpperBound(1) &&
               input[xShapedMasPosition.ARow, xShapedMasPosition.AColumn] == 'A' &&
               xShapedMasPosition.M2Row <= input.GetUpperBound(0) &&
               xShapedMasPosition.M2Column <= input.GetUpperBound(1) &&
               input[xShapedMasPosition.M2Row, xShapedMasPosition.M2Column] == 'M' &&
               xShapedMasPosition.S2Row <= input.GetUpperBound(0) &&
               xShapedMasPosition.S2Column <= input.GetUpperBound(1) &&
               input[xShapedMasPosition.S2Row, xShapedMasPosition.S2Column] == 'S';
    }
}