namespace StringCalculator.Core.Interfaces
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(IEnumerable<string> tokens);
    }
}
