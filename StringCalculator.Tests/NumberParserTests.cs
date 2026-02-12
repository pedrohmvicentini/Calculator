using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class NumberParserTests
    {
        private readonly NumberParser _parser = new();

        [Fact]
        public void Parse_ShouldReturnParsedNumbers_WhenAllTokensAreValid()
        {
            var tokens = new[] { "1", "2", "3" };

            var result = _parser.Parse(tokens);

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnZero_WhenTokenIsInvalid()
        {
            var tokens = new[] { "1", "abc", "3" };

            var result = _parser.Parse(tokens);

            Assert.Equal(new[] { 1, 0, 3 }, result);
        }

        [Fact]
        public void Parse_ShouldHandleNegativeNumbers()
        {
            var tokens = new[] { "-5", "10" };

            var result = _parser.Parse(tokens);

            Assert.Equal(new[] { -5, 10 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnZero_ForEmptyStringToken()
        {
            var tokens = new[] { "" };

            var result = _parser.Parse(tokens);

            Assert.Equal(new[] { 0 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnEmpty_WhenTokensAreEmpty()
        {
            var tokens = Enumerable.Empty<string>();

            var result = _parser.Parse(tokens);

            Assert.Empty(result);
        }

        [Fact]
        public void Parse_ShouldEvaluateLazily()
        {
            var tokens = new List<string> { "1", "2", "3" };

            var result = _parser.Parse(tokens);

            // Modify source before enumeration
            tokens[0] = "10";

            Assert.Equal(new[] { 10, 2, 3 }, result.ToList());
        }
    }
}
