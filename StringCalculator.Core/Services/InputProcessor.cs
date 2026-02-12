using StringCalculator.Core.Interfaces;
using System.Text.RegularExpressions;

namespace StringCalculator.Core.Services
{
    public class InputProcessor : IInputProcessor
    {
        private static readonly string[] DefaultDelimiters = [",", "\\n"];

        public IEnumerable<string> ExtractTokens(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ["0"];

            var delimiters = new List<string>(DefaultDelimiters);

            if (input.StartsWith("//"))
            {
                var newlineIndex = input.IndexOf('\n');
                var delimiter = input.Substring(2, newlineIndex - 2);

                delimiters.Add(delimiter);

                input = input[(newlineIndex + 1)..];
            }

            var pattern = string.Join("|", delimiters.Select(Regex.Escape));

            return Regex.Split(input, pattern);
        }
    }
}
