using Solid.Abstracts;
using Solid.Common;
using Solid.Options;

namespace Solid.Implementations;

public class StatusGameService : IStatusGameService
{
    private readonly IOutputService _outputService;
    private readonly NumberSettings  _numberSettings;

    public StatusGameService(IOutputService outputService, NumberSettings numberSettings)
    {
        _numberSettings = numberSettings;
        _outputService = outputService;
    }

    public GameResultType? Check(int curRetries, DecisionNumberType decisionNumber, int goal = 0)
    {
        if (decisionNumber == DecisionNumberType.Equal)
        {
            _outputService.PrintWon();
            return GameResultType.Won;
        }

        if (curRetries > _numberSettings.RetryCount)
        {
            _outputService.PrintLose(goal);
            return GameResultType.Lost;
        }

        return null;
    }
}