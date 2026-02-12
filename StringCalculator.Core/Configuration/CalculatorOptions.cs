namespace StringCalculator.Core.Configuration
{
    public class CalculatorOptions
    {
        public bool LimitToTwoNumbers { get; init; } = false;
        public bool DenyNegatives { get; init; } = true;
        public int UpperBound { get; init; } = 1000;
    }
}
