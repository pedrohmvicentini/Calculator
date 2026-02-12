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
        public void ExtractTokens_ShouldReturnSingleValue_WhenNoCommaExists()
        {
            var result = _processor.ExtractTokens("5");

            Assert.Single(result);
            Assert.Equal("5", result.First());
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenTrailingComma()
        {
            var result = _processor.ExtractTokens("1,2,");

            Assert.Equal(new[] { "1", "2", "" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenLeadingComma()
        {
            var result = _processor.ExtractTokens(",1,2");

            Assert.Equal(new[] { "", "1", "2" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldReturnEmptyToken_WhenConsecutiveCommas()
        {
            var result = _processor.ExtractTokens("1,,2");

            Assert.Equal(new[] { "1", "", "2" }, result);
        }
    }
}
