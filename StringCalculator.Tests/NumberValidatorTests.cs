using StringCalculator.Core.Configuration;
using StringCalculator.Core.Exceptions;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class NumberValidatorTests
    {
        [Fact]
        public void Validate_ShouldNotThrow_WhenLimitDisabled_AndMoreThanTwoNumbers()
        {
            var options = new CalculatorOptions
            {
                LimitToTwoNumbers = false
            };

            var validator = new NumberValidator(options);
            var numbers = new List<int> { 1, 2, 3, 4 };

            validator.Validate(numbers);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Validate_ShouldNotThrow_WhenLimitEnabled_AndTwoOrLessNumbers(int count)
        {
            var options = new CalculatorOptions
            {
                LimitToTwoNumbers = true
            };

            var validator = new NumberValidator(options);
            var numbers = Enumerable.Repeat(1, count).ToList();

            validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldThrow_WhenLimitEnabled_AndMoreThanTwoNumbers()
        {
            var options = new CalculatorOptions
            {
                LimitToTwoNumbers = true
            };

            var validator = new NumberValidator(options);
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Throws<TooManyNumbersException>(() =>
                validator.Validate(numbers));
        }
    }
}
