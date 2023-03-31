using System.Text.RegularExpressions;
namespace StringCalculator.Console;

public class CalculatorInput
{
    private IEnumerable<int> _numbersInt;
    private readonly int _maxValue;
    public string Numbers { get; }

    public CalculatorInput(string numbers)
    {
        Numbers = numbers;
        _numbersInt = new List<int>();
        _maxValue = 1000;
    }

    public int SumNumbers()
    {
        _numbersInt = TransformNumbersDelimiter();
        HasNegativeNumbers();
        return _numbersInt.Where(x => x <= _maxValue).ToArray().Sum();
    }

    private IEnumerable<int> TransformNumbersDelimiter()
    {
        var regex = new Regex(@"-?\d+(?!(?<=\[).+?(?=\]))");
        var matchNumbers = regex.ExecuteRegex(calculatorInput: this);
        return GetNumbersMatch(matchNumbers);
    }

    private void HasNegativeNumbers()
    {
        if (GetNegativesNumbers().Length > 0)
        {
            throw new InvalidDataException($"negatives not allowed {GetNegativesNumbers()}");
        }
    }

    private static IEnumerable<int> GetNumbersMatch(IEnumerable<Match> matchNumbers)
    {
        return matchNumbers.Aggregate(new int[] { }, (current, number) => current.Append(Convert.ToInt32(number.Value)).ToArray());
    }

    private string GetNegativesNumbers()
    {
        return string.Join(",", _numbersInt.Where(x => x < 0).ToArray());
    }
}