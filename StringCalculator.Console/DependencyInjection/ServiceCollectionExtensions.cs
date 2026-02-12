using Microsoft.Extensions.DependencyInjection;
using StringCalculator.Core.Configuration;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;

namespace StringCalculator.Console.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStringCalculator(
        this IServiceCollection services,
        CalculatorOptions options)
        {
            services.AddSingleton(options);

            services.AddSingleton<IInputProcessor, InputProcessor>();
            services.AddSingleton<INumberParser, NumberParser>();
            services.AddSingleton<INumberValidator, NumberValidator>();
            services.AddSingleton<ICalculator, Calculator>();

            return services;
        }
    }
}
