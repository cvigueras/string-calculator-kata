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
        public void return_zero_when_empty_string_is_given()
        {
            var result = Calculator.Add("");
            result.Should().Be(0);
        }

        [TestCase("5", 5)]
        [TestCase("1", 1)]
        [TestCase("3", 3)]
        public void return_number_when_only_one_number_is_given(string givenNumber, int expectedResult)
        {
            var result = Calculator.Add(givenNumber);
            result.Should().Be(expectedResult);
        }

        [TestCase("5,1",6)]
        [TestCase("3,2",5)]
        [TestCase("7,9",16)]
        public void return_sum_when_two_numbers_are_given(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [TestCase("1,5,7",13)]
        [TestCase("3,8,9",20)]
        [TestCase("7,18,12",37)]
        public void return_sum_when_more_than_two_numbers_are_given(string input, int expectedResult)
        {
            var result = Calculator.Add(input);
            result.Should().Be(expectedResult);
        }

        [Test]
        public void return_sum_two_numbers_when_has_car_return_and_comma_separator()
        {
            var result = Calculator.Add("1\n2,3");
            result.Should().Be(6);
        }

        [Test]
        public void return_sum_other_two_numbers_when_has_car_return_and_comma_separator()
        {
            var result = Calculator.Add("1\n6,9");
            result.Should().Be(16);
        }
    }
}