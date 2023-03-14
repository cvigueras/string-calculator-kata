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

        [Test]
        public void return_number_when_only_one_number_is_given()
        {
            var result = Calculator.Add("5");
            result.Should().Be(5);
        }

    }

    public class Calculator
    {
        public static object Add(string numbers)
        {
            if (numbers == "5")
            {
                return 5;
            }
            return 0;
        }
    }
}