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
                var delimiterSectionEnd = input.IndexOf('\n');
                var delimiterSection = input.Substring(2, delimiterSectionEnd - 2);

                var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        delimiters.Add(match.Groups[1].Value);
                }
                else
                {
                    delimiters.Add(delimiterSection);
                }

                input = input[(delimiterSectionEnd + 1)..];
            }

            var pattern = string.Join("|", delimiters.Select(Regex.Escape));

            return Regex.Split(input, pattern);
        }
    }
}
