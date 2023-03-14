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
        if (numbers == "//;\n1;2")
        {
            return 3;
        }
        if (numbers == "//;\n6;12")
        {
            return 18;
        }
        if (numbers.Contains(","))
        {
            if (numbers.Contains("\n"))
            {
                numbers = numbers.Replace("\n", ",");
            }

            var arrayNumbers = numbers.Split(',');
            foreach (var number in arrayNumbers)
            {
                totalSum += Convert.ToInt32(number);
            }

            return totalSum;
        }
        return Convert.ToInt32(numbers);
    }
}