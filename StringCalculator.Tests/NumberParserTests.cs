using StringCalculator.Core.Configuration;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class NumberParserTests
    {
        private static NumberParser CreateParser(int upperBound = 1000)
        {
            var options = new CalculatorOptions
            {
                UpperBound = upperBound
            };

            return new NumberParser(options);
        }

        [Fact]
        public void Parse_ShouldReturnValidNumbers_WhenWithinUpperBound()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "1", "50", "100" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { 1, 50, 100 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnZero_WhenTokenIsInvalid()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "1", "abc", "3" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { 1, 0, 3 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnZero_WhenNumberExceedsUpperBound()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "50", "150", "75" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { 50, 0, 75 }, result);
        }

        [Fact]
        public void Parse_ShouldAllowNumberEqualToUpperBound()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "100" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { 100 }, result);
        }

        [Fact]
        public void Parse_ShouldAllowNegativeNumbers()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "-5", "10" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { -5, 10 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnZero_ForEmptyStringToken()
        {
            var parser = CreateParser(100);
            var tokens = new[] { "" };

            var result = parser.Parse(tokens);

            Assert.Equal(new[] { 0 }, result);
        }

        [Fact]
        public void Parse_ShouldReturnEmpty_WhenTokensAreEmpty()
        {
            var parser = CreateParser(100);
            var tokens = Enumerable.Empty<string>();

            var result = parser.Parse(tokens);

            Assert.Empty(result);
        }

        [Fact]
        public void Parse_ShouldEvaluateLazily()
        {
            var parser = CreateParser(100);

            var tokens = new List<string> { "1", "2", "3" };
            var result = parser.Parse(tokens);

            // Modify before enumeration
            tokens[0] = "10";

            Assert.Equal(new[] { 10, 2, 3 }, result.ToList());
        }
    }
}
