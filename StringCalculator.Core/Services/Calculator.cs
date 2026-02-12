using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class Calculator(
        IInputProcessor processor,
        INumberParser parser,
        INumberValidator validator) : ICalculator
    {
        public int Add(string input)
        {
            var tokens = processor.ExtractTokens(input);
            var numbers = parser.Parse(tokens).ToList();

            validator.Validate(numbers);

            return numbers.Sum();
        }
    }
}
