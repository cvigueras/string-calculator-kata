using System.Text.RegularExpressions;

namespace StringCalculator.Console;

public class CalculatorInput
{
    public CalculatorInput(string numbers)
    {
        Numbers = numbers;
    }
    public string Numbers { get; }

    public IEnumerable<int> TransformNumbersDelimiter()
    {
        var numbersCollection = new Regex(@"-?\d+(?!(?<=\[).+?(?=\]))").Matches(Numbers).ToArray();
        return (numbersCollection.Aggregate(new int[] { }, (current, number) => current.Append(Convert.ToInt32(number.Value)).ToArray()));
    }
}