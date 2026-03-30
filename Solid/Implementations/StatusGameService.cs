using Solid.Abstracts;
using Solid.Common;
using Solid.Options;

namespace Solid.Implementations;

public class StatusGameService : IStatusGameService
{
    private readonly NumberSettings _numberSettings;

    public StatusGameService(NumberSettings numberSettings)
    {
        _numberSettings = numberSettings;
    }

    public GameResultType? Check(int curRetries, DecisionNumberType decisionNumber)
    {
        if (decisionNumber == DecisionNumberType.Equal)
        {
            return GameResultType.Won;
        }

        if (curRetries > _numberSettings.RetryCount)
        {
            return GameResultType.Lost;
        }

        return null;
    }
}