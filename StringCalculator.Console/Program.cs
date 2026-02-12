using Microsoft.Extensions.DependencyInjection;
using StringCalculator.Console.DependencyInjection;
using StringCalculator.Core.Configuration;
using StringCalculator.Core.Interfaces;

ServiceCollection services = new();

CalculatorOptions options = new();

services.AddStringCalculator(options);

ServiceProvider provider = services.BuildServiceProvider();

ICalculator calculator = provider.GetRequiredService<ICalculator>();

Console.WriteLine("Limit To Two Numbers (0-No, 1-Yes): ");
string? input = Console.ReadLine();
if (int.TryParse(input, out int value) && (value == 0 || value == 1))
    options.LimitToTwoNumbers = value == 1;
else
{
    Console.Write("Invalid answer");
    return;
}

Console.WriteLine("Deny Negatives (0-No, 1-Yes): ");
input = Console.ReadLine();
if (int.TryParse(input, out value) && (value == 0 || value == 1))
    options.DenyNegatives = value == 1;
else
{
    Console.Write("Invalid answer");
    return;
}

Console.WriteLine("Upper Bound (int): ");
input = Console.ReadLine();
if (int.TryParse(input, out value))
    options.UpperBound = value;
else
{
    Console.Write("Invalid answer");
    return;
}

Console.WriteLine("Enter the digits splited by coma (Ctrl+C to exit or digit Exit):");

while (true)
{
    try
    {
        Console.Write("Enter input: ");
        input = Console.ReadLine();

        if (string.Equals(input, "Exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Exiting...");
            break;
        }

        int result = calculator.Add(input ?? string.Empty);
        Console.WriteLine($"Result: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}