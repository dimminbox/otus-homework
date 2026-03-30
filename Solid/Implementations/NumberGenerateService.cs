using Solid.Abstracts;
using Solid.Options;

namespace Solid.Implementations;

public class NumberGenerateService : INumberGenerateService
{
    private readonly NumberSettings _settings;
    private readonly Random _random = new();

    public NumberGenerateService(NumberSettings settings)
    {
        _settings = settings;
    }

    public int Generate()
    {
        return _random.Next(_settings.Range.Start, _settings.Range.End);
    }
}