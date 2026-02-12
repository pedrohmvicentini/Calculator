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

            if (options.DenyNegatives)
            {
                var negatives = numbers.Where(x => x < 0).ToList();

                if (negatives.Count != 0)
                    throw new NegativeNumbersException(negatives);
            }
        }
    }
}
