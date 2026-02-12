using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    public class InputProcessorTests
    {
        private readonly InputProcessor _processor = new();

        [Fact]
        public void ExtractTokens_ShouldSupportCustomDelimiter()
        {
            var result = _processor.ExtractTokens("//#\n2#5");

            Assert.Equal(new[] { "2", "5" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportCommaAsCustomDelimiter()
        {
            var result = _processor.ExtractTokens("//,\n2,ff,100");

            Assert.Equal(new[] { "2", "ff", "100" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportCustomDelimiter_WithMultipleNumbers()
        {
            var result = _processor.ExtractTokens("//;\n1;2;3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldStillSupportDefaultComma()
        {
            var result = _processor.ExtractTokens("1,2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldStillSupportNewLineDelimiter()
        {
            var result = _processor.ExtractTokens("1\\n2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }

        [Fact]
        public void ExtractTokens_ShouldSupportCustomAndDefaultTogether()
        {
            var result = _processor.ExtractTokens("//#\n1#2,3");

            Assert.Equal(new[] { "1", "2", "3" }, result);
        }
    }
}
