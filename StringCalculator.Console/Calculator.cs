using System.Text.RegularExpressions;

namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(CalculatorInput calculatorInput)
    {
        if (string.IsNullOrEmpty(calculatorInput.Numbers)) return 0;
        var numbers = calculatorInput.Numbers;
        var numbersCollection = TransformNumbersDelimiter(new CalculatorInput(numbers)).ToList();
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

    private static IEnumerable<int> TransformNumbersDelimiter(CalculatorInput calculatorInput)
    {
        var numbersCollection = new Regex(@"-?\d+(?!(?<=\[).+?(?=\]))").Matches(calculatorInput.Numbers).ToArray();
        return (numbersCollection.Aggregate(new int[] { }, (current, number) => current.Append(Convert.ToInt32(number.Value)).ToArray()));
    }
}