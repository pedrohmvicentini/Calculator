namespace StringCalculator.Core.Configuration
{
    public class CalculatorOptions
    {
        public bool DenyNegatives { get; init; } = true;
        public bool LimitToTwoNumbers { get; init; } = false;
    }
}
