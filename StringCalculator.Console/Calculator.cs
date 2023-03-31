namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(CalculatorInput calculatorInput)
    {
        if (string.IsNullOrEmpty(calculatorInput.Numbers)) return 0;
        var calculator = new CalculatorInput(calculatorInput.Numbers);
        return calculator.SumNumbers();
    }
}