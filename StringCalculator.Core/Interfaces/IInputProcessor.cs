namespace StringCalculator.Core.Interfaces
{
    public interface IInputProcessor
    {
        IEnumerable<string> ExtractTokens(string input);
    }
}
