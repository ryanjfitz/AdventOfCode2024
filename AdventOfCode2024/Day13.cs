namespace AdventOfCode2024;

public static class Day13
{
    public static long GetMinimumNumberOfTokensToWin(string input, bool isPart2 = false)
    {
        return input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Chunk(3)
            .Sum(lines => GetMinimumNumberOfTokensToWin(lines, isPart2));
    }

    private static long GetMinimumNumberOfTokensToWin(string[] lines, bool isPart2)
    {
        string buttonALine = lines[0];
        string buttonBLine = lines[1];
        string prizeLine = lines[2];
        string[] prizeLineSplit = prizeLine.Split(',');

        Equation equation1 = new Equation(
            XCoefficient: Convert.ToDouble(buttonALine.Substring(12, 2)),
            YCoefficient: Convert.ToDouble(buttonBLine.Substring(12, 2)),
            Constant: Convert.ToDouble(prizeLineSplit[0].Substring(prizeLineSplit[0].IndexOf('=') + 1)));
        Equation equation2 = new Equation(
            XCoefficient: Convert.ToDouble(buttonALine.Substring(18, 2)),
            YCoefficient: Convert.ToDouble(buttonBLine.Substring(18, 2)),
            Constant: Convert.ToDouble(prizeLineSplit[1].Substring(prizeLineSplit[1].IndexOf('=') + 1)));

        if (isPart2)
        {
            equation1 = equation1 with { Constant = equation1.Constant + 10000000000000 };
            equation2 = equation2 with { Constant = equation2.Constant + 10000000000000 };
        }

        (double X, double Y) solution = EquationSolver.Solve(equation1, equation2);

        if (!solution.X.Equals((long)solution.X) || !solution.Y.Equals((long)solution.Y))
        {
            return 0;
        }

        return (long)(solution.X * 3 + solution.Y);
    }

    private static class EquationSolver
    {
        public static (double X, double Y) Solve(Equation equation1, Equation equation2)
        {
            var scaledXEquation1 = new Equation(
                XCoefficient: equation1.XCoefficient * equation2.XCoefficient,
                YCoefficient: equation1.YCoefficient * equation2.XCoefficient,
                Constant: equation1.Constant * equation2.XCoefficient);
            var scaledXEquation2 = new Equation(
                XCoefficient: equation2.XCoefficient * equation1.XCoefficient,
                YCoefficient: equation2.YCoefficient * equation1.XCoefficient,
                Constant: equation2.Constant * equation1.XCoefficient);

            var subtractedEquation = new Equation(
                XCoefficient: 0,
                YCoefficient: scaledXEquation2.YCoefficient - scaledXEquation1.YCoefficient,
                Constant: scaledXEquation2.Constant - scaledXEquation1.Constant);

            double y = subtractedEquation.Constant / subtractedEquation.YCoefficient;

            double x = (equation1.Constant - equation1.YCoefficient * y) / equation1.XCoefficient;

            return (x, y);
        }
    }

    private record Equation(double XCoefficient, double YCoefficient, double Constant);
}