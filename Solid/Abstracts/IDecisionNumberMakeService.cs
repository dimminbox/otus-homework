using Solid.Common;

namespace Solid.Abstracts;

public interface IDecisionNumberMakeService
{
    DecisionNumberType Check(int number, int goal);
    int GetCurrentRetry();
}