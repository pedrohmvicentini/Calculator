namespace StringCalculator.Core.Exceptions
{
    public class NegativeNumbersException : Exception
    {
        public NegativeNumbersException(IEnumerable<int> negatives)
            : base($"Negative numbers not allowed: {string.Join(", ", negatives)}")
        {
        }
    }
}
