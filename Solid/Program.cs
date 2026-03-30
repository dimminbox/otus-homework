using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Solid.Abstracts;
using Solid.Common;
using Solid.Options;

namespace Solid;

public class Program
{
    public static void Main(string[] args)
    {
        var options = ParseOptions(args);
        
        var services = new ServiceCollection();
        ConfigureServices(services, options);
        var provider = services.BuildServiceProvider();

        var numberGenerateService = provider.GetRequiredService<INumberGenerateService>();
        var outputService = provider.GetRequiredService<IOutputService>();
        var decisionNumberMakeService = provider.GetRequiredService<IDecisionNumberMakeService>();
        var statusGameService = provider.GetRequiredService<IStatusGameService>();

        var guessedWord = numberGenerateService.Generate();

        while (true)
        {
            Console.WriteLine("Please enter a number:");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var number))
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            var decisionNumberType = decisionNumberMakeService.Check(number, guessedWord);
            var decision = statusGameService.Check(decisionNumberMakeService.GetCurrentRetry(), decisionNumberType);
            if (decision == GameResultType.Won)
            {
                outputService.PrintWon();
                return;
            }

            if (decision == GameResultType.Lost)
            {
                outputService.PrintLose();
                Console.WriteLine($"The number was: {guessedWord}");
                return;
            }

            if (decision != null)
            {
                return;
            }
        }
    }

    private static void ConfigureServices(IServiceCollection services, CliOptions options)
    {
        services.AddDependencies(options);
        services.AddSingleton(ConfigureNumberSettings(options));
    }

    private static CliOptions ParseOptions(string[] args)
    {
        CliOptions result = null;
        var parser = new Parser(with => with.HelpWriter = Console.Out);

        parser.ParseArguments<CliOptions>(args)
            .WithParsed(o => result = o)
            .WithNotParsed(errors =>
            {
                // Errors already printed by HelpWriter
                result = null;
            });

        return result;
    }

    private static NumberSettings ConfigureNumberSettings(CliOptions options) =>
        new NumberSettings(options.Retry, new ValueRange<int>(options.Min, options.Max));
}