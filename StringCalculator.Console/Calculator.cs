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
        string negativesNumbers = string.Empty;
        foreach (var number in numbers)
        {
            if (Convert.ToInt32(number) < 0)
            {
                negativesNumbers += negativesNumbers == string.Empty ? $"{number}" : $",{number}";
            }
        }

        if (negativesNumbers.Length > 0)
        {
            throw new InvalidDataException($"negatives not allowed {negativesNumbers}");
        }
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

        var arrayNumbers = numbers.Split(',');
        return arrayNumbers;
    }

    private static int SumTotalNumbers(string[] numbers)
    {
        var totalSum = 0;
        foreach (var number in numbers)
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