using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class NumberParser() : INumberParser
    {
        public IEnumerable<int> Parse(IEnumerable<string> tokens)
        {
            foreach (var token in tokens)
            {
                if (!int.TryParse(token, out var number))
                {
                    yield return 0;
                    continue;
                }

                yield return number;
            }
        }
    }
}
