namespace StringCalculator.Core.Exceptions
{
    public class TooManyNumbersException : Exception
    {
        public TooManyNumbersException()
            : base("Only two numbers are allowed.")
        {
        }
    }
}
