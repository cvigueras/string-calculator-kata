using FluentAssertions;
using StringCalculator.Console;

namespace StringCalculator.Test
{
    public class CalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void return_zero_when_empty_string_given()
        {
            var result = Calculator.Add("");
            result.Should().Be(0);
        }

        [TestCase("5", 5)]
        [TestCase("1", 1)]
        [TestCase("3", 3)]
        public void return_number_when_only_one_number_given(string givenNumber, int expectedResult)
        {
            var result = Calculator.Add(givenNumber);
            result.Should().Be(expectedResult);
        }

        [TestCase("5,1",6)]
        [TestCase("3,2",5)]
        [TestCase("7,9",16)]
        public void sum_when_two_numbers_given(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [TestCase("1,5,7",13)]
        [TestCase("3,8,9",20)]
        [TestCase("7,18,12",37)]
        public void sum_when_more_than_two_numbers_given(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [TestCase("1\n2,3",6)]
        [TestCase("1\n6,9",16)]
        [TestCase("1\n8,19",28)]
        public void sum_numbers_when_has_car_return_and_comma_separator(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [TestCase("//;\n1;2",3)]
        [TestCase("//;\n6;12",18)]
        [TestCase("//;\n16;22",38)]
        public void sum_numbers_with_delimiter_given(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [Test]
        public void throw_exception_with_negative_number()
        {
            var givenNumber = "-1";
            Action action = () => Calculator.Add(givenNumber);
            action.Should().Throw<InvalidDataException>()
                .WithMessage($"negatives not allowed {givenNumber}");
        }

        [Test]
        public void throw_exception_with_other_negative_number()
        {
            var givenNumber = "-7";
            Action action = () => Calculator.Add(givenNumber);
            action.Should().Throw<InvalidDataException>()
                .WithMessage($"negatives not allowed {givenNumber}");
        }

        [Test]
        public void throw_exception_with_another_negative_number()
        {
            var givenNumber = "-17";
            Action action = () => Calculator.Add(givenNumber);
            action.Should().Throw<InvalidDataException>()
                .WithMessage($"negatives not allowed {givenNumber}");
        }

        [Test]
        public void throw_exception_with_many_negative_number()
        {
            var givenNumbers = "5,-17,3,-8,-9,7";
            var expectedNumbers = "-17,-8,-9";
            Action action = () => Calculator.Add(givenNumbers);
            action.Should().Throw<InvalidDataException>()
                .WithMessage($"negatives not allowed {expectedNumbers}");
        }

        [Test]
        public void return_0_if_number_is_greater_than_1000()
        {
            var givenNumbers = "1001";
            var result = Calculator.Add(givenNumbers);
            result.Should().Be(0);
        }


        [Test]
        public void not_sum_number_if_is_greater_than_1000()
        {
            var givenNumbers = "1000,999,1002,1005,3,0";
            var expectedResult = 2002;
            var result = Calculator.Add(givenNumbers);
            result.Should().Be(expectedResult);
        }

        [Test]
        public void return_sum_with_specific_delimiter()
        {
            var givenNumbers = "//[***]\n1***2***3";
            var result = Calculator.Add(givenNumbers);
            result.Should().Be(6);
        }

    }
}