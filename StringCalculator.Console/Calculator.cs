namespace StringCalculator.Console;

public class Calculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var arrayNumbers = TransformToArrayNumbers(numbers);
        HasNegativeNumbers(arrayNumbers);
        return SumTotalNumbers(arrayNumbers);
    }

    private static void HasNegativeNumbers(string[] numbers)
    {
        ThrowInvalidDataException(BuildMessageNegativeNumbers(numbers));
    }

    private static void ThrowInvalidDataException(string negativesNumbers)
    {
        if (negativesNumbers.Length > 0)
        {
            throw new InvalidDataException($"negatives not allowed {negativesNumbers}");
        }
    }

    private static string BuildMessageNegativeNumbers(string[] numbers)
    {
        return string.Join(",", numbers.Where(x => Convert.ToInt32(x) < 0).ToArray());
    }

    private static string[] TransformToArrayNumbers(string numbers)
    {
        if (numbers.Contains("//"))
        {
            numbers = TransformNumbersDelimiter(numbers);
        }

        if (numbers.Contains("\n"))
        {
            numbers = TransformNumbersWithReturnLine(numbers);
        }

        return numbers.Split(',');
    }

    private static int SumTotalNumbers(string[] numbers)
    {
        return numbers.Where(x=> Convert.ToInt32(x) <= 1000).ToArray().Sum(int.Parse);
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