namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        return SumNumbers(numbers);
    }

    private static int SumNumbers(string numbers)
    {
        var totalSum = 0;
        if (!numbers.Contains(",")) return Convert.ToInt32(numbers);
        var arrayNumbers = numbers.Split(',');
        foreach (var number in arrayNumbers)
        {
            totalSum += Convert.ToInt32(number);
        }
        return totalSum;

    }
}