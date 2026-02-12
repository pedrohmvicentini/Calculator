using StringCalculator.Core.Configuration;
using StringCalculator.Core.Exceptions;
using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class NumberValidator(CalculatorOptions options) : INumberValidator
    {
        public void Validate(IReadOnlyCollection<int> numbers)
        {
            if (options.LimitToTwoNumbers && numbers.Count > 2)
                throw new TooManyNumbersException();
        }
    }
}
