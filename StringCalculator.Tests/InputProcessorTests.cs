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
        public void ExtractTokens_ShouldReturnZero_WhenInputIsNullOrWhitespace(string input)
        {
            var result = _processor.ExtractTokens(input);

            Assert.Single(result);
            Assert.Equal("0", result.First());
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByComma()
        {
            var result = _processor.ExtractTokens("1,2,3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByNewLine()
        {
            var result = _processor.ExtractTokens("1\\n2\\n3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSplitByCommaAndNewLine()
        {
            var result = _processor.ExtractTokens("1,2\\n3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportSingleCustomDelimiter()
        {
            var result = _processor.ExtractTokens("//;\n1;2;3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportMultiCharacterCustomDelimiter()
        {
            var result = _processor.ExtractTokens("//[***]\n1***2***3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportMultipleCustomDelimiters()
        {
            var result = _processor.ExtractTokens("//[*][%]\n1*2%3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportMultipleMultiCharacterDelimiters()
        {
            var result = _processor.ExtractTokens("//[***][%%]\n1***2%%3");

            Assert.Equal(["1", "2", "3"], result);
        }

        [Fact]
        public void ExtractTokens_ShouldHandleSpecialRegexCharactersInDelimiter()
        {
            var result = _processor.ExtractTokens("//[.]\n1.2.3");

            Assert.Equal(["1", "2", "3"], result);
        }
    }
}
