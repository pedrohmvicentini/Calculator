namespace StringCalculator.Core.Interfaces
{
    public interface INumberValidator
    {
        void Validate(IReadOnlyCollection<int> numbers);
    }
}
