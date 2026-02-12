using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class InputProcessorTests
    {
        private readonly InputProcessor _processor = new();

        [Fact]
        public void ExtractTokens_ShouldSupportMultiCharacterDelimiter()
        {
            var result = _processor.ExtractTokens("//[***]\\n11***22***33");

            Assert.Equal(new[] { "11", "22", "33" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportSingleCharacterDelimiter()
        {
            var result = _processor.ExtractTokens("//#\n2#5");

            Assert.Equal(new[] { "2", "5" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldStillSupportComma()
        {
            var result = _processor.ExtractTokens("1,2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldStillSupportNewLine()
        {
            var result = _processor.ExtractTokens("1\\n2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportCustomAndDefaultTogether()
        {
            var result = _processor.ExtractTokens("//[***]\\n1***2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }
    }
}
