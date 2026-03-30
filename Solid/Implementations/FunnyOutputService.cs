namespace Solid.Implementations;

public class FunnyOutputService : BaseOutputService
{
    protected override string WonMessage => "Splendid! You spot on!";
    protected override string LoseMessage => "Unfortunately! Game over.";
    protected override string MoreMessage => " It's more than a goal.";
    protected override string LessMessage => " It's less than a goal.";

    protected override ConsoleColor WinColor => ConsoleColor.Magenta;
    protected override ConsoleColor LoseColor => ConsoleColor.DarkRed;
}