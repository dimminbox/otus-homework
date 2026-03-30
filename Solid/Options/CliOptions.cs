using CommandLine;

namespace Solid.Options;

public class CliOptions
{
    [Option("retry", Required = true)]
    public int Retry { get; set; }

    [Option("min", Required = true)]
    public int Min { get; set; }

    [Option("max", Required = true)]
    public int Max { get; set; }

    [Option("output", Default = OutputType.Default, HelpText = "Output style: Default, Funny, Silent")]
    public OutputType OutputType { get; set; }
}

public enum OutputType
{
    Default,
    Funny,
    Silent
}