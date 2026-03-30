namespace Solid.Implementations;

public class OutputService : BaseOutputService
{
    protected override string WonMessage => "Splendid! You spot on!";
    protected override string LoseMessage => "Unfortunately! The game is over.";
    protected override string MoreMessage => "It's more than a goal.";
    protected override string LessMessage => "It's less than a goal.";
}