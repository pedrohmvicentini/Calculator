using StringCalculator.Core.Exceptions;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class NumberValidatorTests
    {
        private readonly NumberValidator _validator = new();

        [Fact]
        public void Validate_ShouldNotThrow_WhenNoNumbers()
        {
            var numbers = new List<int>();

            _validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldNotThrow_WhenOneNumber()
        {
            var numbers = new List<int> { 1 };

            _validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldNotThrow_WhenTwoNumbers()
        {
            var numbers = new List<int> { 1, 2 };

            _validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldThrow_WhenMoreThanTwoNumbers()
        {
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Throws<TooManyNumbersException>(() => _validator.Validate(numbers));
        }

        [Fact]
        public void Validate_ShouldThrow_WhenManyNumbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Assert.Throws<TooManyNumbersException>(() => _validator.Validate(numbers));
        }
    }
}
