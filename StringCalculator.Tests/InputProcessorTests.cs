using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class InputProcessorTests
    {
        private readonly InputProcessor _processor = new();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ExtractTokens_ShouldReturnZero_WhenInputIsNullOrWhiteSpace(string input)
        {
            var result = _processor.ExtractTokens(input);

            Assert.Single(result);
            Assert.Equal("0", result.First());
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByComma()
        {
            var result = _processor.ExtractTokens("1,2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByNewLine()
        {
            var result = _processor.ExtractTokens("1\\n2\\n3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByCommaAndNewLine()
        {
            var result = _processor.ExtractTokens("1\\n2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenConsecutiveDelimiters()
        {
            var result = _processor.ExtractTokens("1,\\n2");

            Assert.Equal(new[] { "1", "", "2" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenTrailingDelimiter()
        {
            var result = _processor.ExtractTokens("1,2,");

            Assert.Equal(new[] { "1", "2", "" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenLeadingDelimiter()
        {
            var result = _processor.ExtractTokens(",1,2");

            Assert.Equal(new[] { "", "1", "2" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnSingleToken_WhenNoDelimiterExists()
        {
            var result = _processor.ExtractTokens("5");

            Assert.Equal(new[] { "5" }, result);
        }
    }
}
