using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class InputProcessor : IInputProcessor
    {
        public IEnumerable<string> ExtractTokens(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ["0"];

            return input.Split(",");
        }
    }
}
