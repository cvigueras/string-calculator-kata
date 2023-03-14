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
            var result = Calculator.Add();
            result.Should().Be(0);
        }

    }

    public class Calculator
    {
        public static object Add()
        {
            return 0;
        }
    }
}