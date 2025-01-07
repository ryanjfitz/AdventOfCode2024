using System.Collections.Concurrent;

namespace AdventOfCode2024;

public static class Day7
{
    private static readonly ConcurrentDictionary<string, string[][]> Cache = new();

    public static long GetTotalCalibrationResult(string input, bool allowConcatenation = false)
    {
        return input.Split(Environment.NewLine)
            .Select(s => GetIndividualCalibrationResult(s, allowConcatenation))
            .Sum();
    }

    private static long GetIndividualCalibrationResult(string input, bool allowConcatenation)
    {
        string[] split = input.Split(':');
        long testValue = long.Parse(split[0]);
        long[] numbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

        var operatorCombinations = GetOperatorCombinations(allowConcatenation, numbers.Length - 1);

        if (operatorCombinations.AsParallel()
            .Any(operatorCombination => DoMath(numbers, operatorCombination) == testValue))
        {
            return testValue;
        }

        return 0;
    }

    private static string[][] GetOperatorCombinations(bool allowConcatenation, int combinationLength)
    {
        return Cache.GetOrAdd($"{allowConcatenation}{combinationLength}", _ =>
        {
            List<string> operators = ["+", "*"];
            if (allowConcatenation)
            {
                operators.Add("||");
            }

            int combinationCount = (int)Math.Pow(operators.Count, combinationLength);

            var combinations = new string[combinationCount][];

            for (int i = 0; i < combinationCount; i++)
            {
                string[] combination = new string[combinationLength];

                int temp = i;
                for (int j = 0; j < combinationLength; j++)
                {
                    combination[j] = operators[temp % operators.Count];
                    temp /= operators.Count;
                }

                combinations[i] = combination;
            }

            return combinations;
        });
    }

    private static long DoMath(long[] numbers, IEnumerable<string> operators)
    {
        var operatorStack = new Stack<string>(operators);

        long result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            string @operator = operatorStack.Pop();

            switch (@operator)
            {
                case "+":
                    result += numbers[i];
                    break;
                case "*":
                    result *= numbers[i];
                    break;
                case "||":
                    result = long.Parse(string.Concat(result, numbers[i]));
                    break;
            }
        }

        return result;
    }
}