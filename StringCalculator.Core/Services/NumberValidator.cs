using StringCalculator.Core.Exceptions;
using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class NumberValidator() : INumberValidator
    {
        public void Validate(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count > 2)
                throw new TooManyNumbersException();
        }
    }
}
