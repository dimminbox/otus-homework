using Solid.Abstracts;
using Solid.Common;
using Solid.Options;

namespace Solid.Implementations;

public class DecisionNumberMakeService : IDecisionNumberMakeService
{
    private int retry { get; set; }
    private readonly IOutputService _outputService;

    public DecisionNumberMakeService(IOutputService outputService)
    {
        _outputService = outputService;
    }

    public DecisionNumberType Check(int number, int goal)
    {
        if (number == goal)
        {
            return DecisionNumberType.Equal;
        }

        retry++;
        
        if (number < goal)
        {
            _outputService.PrintLess();
            return DecisionNumberType.Less;
        }
        
        _outputService.PrintMore();
        return DecisionNumberType.More;
    }

    public int GetCurrentRetry()
    {
        return retry;
    }
}