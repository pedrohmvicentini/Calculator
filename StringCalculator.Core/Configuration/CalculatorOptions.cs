namespace StringCalculator.Core.Configuration
{
    public class CalculatorOptions
    {
        public bool LimitToTwoNumbers { get; set; } = false;
        public bool DenyNegatives { get; set; } = true;
        public int UpperBound { get; set; } = 1000;
    }
}
