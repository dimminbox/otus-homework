using Microsoft.Extensions.DependencyInjection;
using Solid.Abstracts;
using Solid.Implementations;
using Solid.Options;

namespace Solid;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, CliOptions options)
    {
        services.AddScoped<IDecisionNumberMakeService, DecisionNumberMakeService>();
        services.AddScoped<INumberGenerateService, NumberGenerateService>();
        services.AddScoped<IStatusGameService, StatusGameService>();

        services.AddSingleton<CliOptions>(options);

        services.AddScoped<IOutputService>(provider =>
        {
            return options.OutputType switch
            {
                OutputType.Funny => new FunnyOutputService(),
                OutputType.Silent => new SilentOutputService(),
                _ => new OutputService()
            };
        });
        return services;
    }
}