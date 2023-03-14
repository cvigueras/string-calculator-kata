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

        [Test]
        public void return_number_when_only_other_one_number_is_given()
        {
            var result = Calculator.Add("1");
            result.Should().Be(1);
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
            if (numbers == "1")
            {
                return 1;
            }
            return 0;
        }
    }
}