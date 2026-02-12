using StringCalculator.Core.Configuration;
using StringCalculator.Core.Exceptions;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class NumberValidatorTests
    {
        private static NumberValidator CreateValidator(
       bool limitToTwo = false,
       bool denyNegatives = false)
        {
            var options = new CalculatorOptions
            {
                LimitToTwoNumbers = limitToTwo,
                DenyNegatives = denyNegatives
            };

            return new NumberValidator(options);
        }

        #region LimitToTwoNumbers

        [Fact]
        public void Validate_ShouldNotThrow_WhenLimitDisabled()
        {
            var validator = CreateValidator(limitToTwo: false);
            var numbers = new List<int> { 1, 2, 3, 4 };

            validator.Validate(numbers);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Validate_ShouldNotThrow_WhenLimitEnabled_AndTwoOrLess(int count)
        {
            var validator = CreateValidator(limitToTwo: true);
            var numbers = Enumerable.Repeat(1, count).ToList();

            validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldThrowTooManyNumbers_WhenLimitEnabled_AndMoreThanTwo()
        {
            var validator = CreateValidator(limitToTwo: true);
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Throws<TooManyNumbersException>(() =>
                validator.Validate(numbers));
        }

        #endregion

        #region DenyNegatives

        [Fact]
        public void Validate_ShouldNotThrow_WhenDenyNegativesDisabled()
        {
            var validator = CreateValidator(denyNegatives: false);
            var numbers = new List<int> { -1, -2 };

            validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldNotThrow_WhenDenyNegativesEnabled_AndNoNegatives()
        {
            var validator = CreateValidator(denyNegatives: true);
            var numbers = new List<int> { 1, 2, 3 };

            validator.Validate(numbers);
        }

        [Fact]
        public void Validate_ShouldThrowNegativeNumbersException_WhenNegativesExist()
        {
            var validator = CreateValidator(denyNegatives: true);
            var numbers = new List<int> { 1, -2, 3, -5 };

            Assert.Throws<NegativeNumbersException>(() =>
                validator.Validate(numbers));
        }

        #endregion

        #region Rule Interaction

        [Fact]
        public void Validate_ShouldThrowTooManyNumbers_First_WhenBothRulesEnabled()
        {
            var validator = CreateValidator(limitToTwo: true, denyNegatives: true);

            var numbers = new List<int> { -1, 2, 3 };

            // Count rule is evaluated first
            Assert.Throws<TooManyNumbersException>(() =>
                validator.Validate(numbers));
        }

        [Fact]
        public void Validate_ShouldThrowNegativeNumbers_WhenWithinLimitButNegativesExist()
        {
            var validator = CreateValidator(limitToTwo: true, denyNegatives: true);

            var numbers = new List<int> { -1, 2 };

            Assert.Throws<NegativeNumbersException>(() =>
                validator.Validate(numbers));
        }

        #endregion
    }
}
