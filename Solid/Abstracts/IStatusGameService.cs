using Solid.Common;

namespace Solid.Abstracts;

public interface IStatusGameService
{
    GameResultType? Check(int curRetries, DecisionNumberType decisionNumber, int goal);
}