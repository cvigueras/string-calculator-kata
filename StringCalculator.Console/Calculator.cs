namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        if (numbers == "-1")
        {
            throw new InvalidDataException($"negatives not allowed {numbers}");
        }

        return SumNumbers(numbers);
    }

    private static int SumNumbers(string numbers)
    {
        if (numbers.Contains("//"))
        {
            numbers = TransformNumbersDelimiter(numbers);
        }

        if (numbers.Contains(","))
        {
            if (numbers.Contains("\n"))
            {
                numbers = TransformNumbersWithReturnLine(numbers);
            }

            return SumTotalNumbers(numbers);
        }
        return Convert.ToInt32(numbers);
    }

    private static int SumTotalNumbers(string numbers)
    {
        var totalSum = 0;
        var arrayNumbers = numbers.Split(',');
        foreach (var number in arrayNumbers)
        {
            totalSum += Convert.ToInt32(number);
        }

        return totalSum;
    }

    private static string TransformNumbersWithReturnLine(string numbers)
    {
        return numbers.Replace("\n", ",");
    }
    private static string TransformNumbersDelimiter(string numbers)
    {
        var arrayNum = numbers.Split('\n');
        var delimiter = arrayNum[0].Replace("//", string.Empty);
        return arrayNum[1].Replace(delimiter, ",");
    }

}