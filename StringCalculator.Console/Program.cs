using Microsoft.Extensions.DependencyInjection;
using StringCalculator.Core.Configuration;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;

ServiceCollection services = new();

CalculatorOptions options = new()
{
    DenyNegatives = true,
    LimitToTwoNumbers = false
};

services.AddSingleton(options);
services.AddSingleton<IInputProcessor, InputProcessor>();
services.AddSingleton<INumberParser, NumberParser>();
services.AddSingleton<INumberValidator, NumberValidator>();
services.AddSingleton<ICalculator, Calculator>();

ServiceProvider provider = services.BuildServiceProvider();

ICalculator calculator = provider.GetRequiredService<ICalculator>();

Console.WriteLine("String Calculator (Ctrl+C to exit or digit Exit)");

while (true)
{
    try
    {
        Console.Write("Enter input: ");
        string? input = Console.ReadLine();

        int result = calculator.Add(input ?? string.Empty);
        Console.WriteLine($"Result: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}