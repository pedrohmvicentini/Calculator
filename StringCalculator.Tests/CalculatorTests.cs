using StringCalculator.Core.Services;

namespace StringCalculator.Tests
{
    using NSubstitute;
    using StringCalculator.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class CalculatorTests
    {
        private readonly IInputProcessor _processor = Substitute.For<IInputProcessor>();
        private readonly INumberParser _parser = Substitute.For<INumberParser>();
        private readonly INumberValidator _validator = Substitute.For<INumberValidator>();

        private Calculator CreateSut()
            => new Calculator(_processor, _parser, _validator);

        [Fact]
        public void Add_ShouldReturnSumOfParsedNumbers()
        {
            var input = "1,2,3";
            var tokens = new[] { "1", "2", "3" };
            var numbers = new List<int> { 1, 2, 3 };

            _processor.ExtractTokens(input).Returns(tokens);
            _parser.Parse(tokens).Returns(numbers);

            var sut = CreateSut();

            var result = sut.Add(input);

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_ShouldCallValidator_WithParsedNumbers()
        {
            var input = "1,2";
            var tokens = new[] { "1", "2" };
            var numbers = new List<int> { 1, 2 };

            _processor.ExtractTokens(input).Returns(tokens);
            _parser.Parse(tokens).Returns(numbers);

            var sut = CreateSut();

            sut.Add(input);

            _validator.Received(1)
                .Validate(Arg.Is<IReadOnlyCollection<int>>(n =>
                    n.SequenceEqual(numbers)));
        }

        [Fact]
        public void Add_ShouldReturnZero_WhenNoNumbers()
        {
            var input = "";
            var tokens = Enumerable.Empty<string>();
            var numbers = new List<int>();

            _processor.ExtractTokens(input).Returns(tokens);
            _parser.Parse(tokens).Returns(numbers);

            var sut = CreateSut();

            var result = sut.Add(input);

            Assert.Equal(0, result);
        }
    }

}
