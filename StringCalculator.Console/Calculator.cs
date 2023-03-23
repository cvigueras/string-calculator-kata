namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(CalculatorInput calculatorInput)
    {
        if (string.IsNullOrEmpty(calculatorInput.Numbers)) return 0;
        var numbers = calculatorInput.Numbers;
        var numbersCollection = new CalculatorInput(numbers).TransformNumbersDelimiter().ToList();
        HasNegativeNumbers(numbersCollection);
        return numbersCollection.Where(x => x <= 1000).ToArray().Sum();
    }

    public static void HasNegativeNumbers(IEnumerable<int> numbers)
    {
        var negativesNumbers = string.Join(",", numbers.Where(x => x < 0).ToArray());
        if (negativesNumbers.Length > 0)
        {
            throw new InvalidDataException($"negatives not allowed {negativesNumbers}");
        }
    }
}