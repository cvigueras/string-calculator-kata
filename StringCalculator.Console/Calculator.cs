using System.Text.RegularExpressions;

namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;
        var numbersCollection = TransformNumbersDelimiter(numbers);
        HasNegativeNumbers(numbersCollection);
        return numbersCollection.Where(x => x <= 1000).ToArray().Sum();
    }

    private static void HasNegativeNumbers(IEnumerable<int> numbers)
    {
        var negativesNumbers = string.Join(",", numbers.Where(x => x < 0).ToArray());
        if (negativesNumbers.Length > 0)
        {
            throw new InvalidDataException($"negatives not allowed {negativesNumbers}");
        }
    }

    private static int[] TransformNumbersDelimiter(string numbers)
    {
        int[] arrayNumbers = { };
        var numbersCollection = new Regex(@"-?\d+(?!(?<=\[).+?(?=\]))").Matches(numbers).ToArray();
        return numbersCollection.Aggregate(arrayNumbers, (current, number) => current.Append(Convert.ToInt32(number.Value)).ToArray());
    }
}