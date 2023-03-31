using System.Text.RegularExpressions;

namespace StringCalculator.Console;

public static class RegexExtension
{
    public static Match[] ExecuteRegex(this Regex regex, CalculatorInput calculatorInput)
    {
        return regex.Matches(calculatorInput.Numbers).ToArray();
    }
}