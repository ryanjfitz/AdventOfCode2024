using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public static class Day3
{
    public static int SumMultiplications(string input)
    {
        return Regex.Matches(input, @"mul\(\d+,\d+\)")
            .Select(match => match.Value.Replace("mul(", "").Replace(")", "").Split(','))
            .Sum(numbers => int.Parse(numbers[0]) * int.Parse(numbers[1]));
    }

    public static int SumMultiplicationsWithInstructions(string input)
    {
        var matchCollection = Regex.Matches(input, @"mul\(\d+,\d+\)|do\(\)|don\'t\(\)");

        bool enable = true;

        int sum = 0;

        foreach (Match match in matchCollection)
        {
            if (match.Value == "do()")
            {
                enable = true;
            }
            else if (match.Value == "don't()")
            {
                enable = false;
            }
            else if (enable)
            {
                var numbers = match.Value.Replace("mul(", "").Replace(")", "").Split(',');

                sum += int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }
        }

        return sum;
    }
}