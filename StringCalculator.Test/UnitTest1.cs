using FluentAssertions;

namespace StringCalculator.Test
{
    public class Tests
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
    }

    public class Calculator
    {
        public static object Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            return Convert.ToInt32(numbers);
        }
    }
}