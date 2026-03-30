using Solid.Abstracts;

namespace Solid.Implementations;

public abstract class BaseOutputService : IOutputService
{
    protected virtual ConsoleColor WinColor => ConsoleColor.Green;
    protected virtual ConsoleColor LoseColor => ConsoleColor.Red;
    protected virtual ConsoleColor BackgroundColor => ConsoleColor.DarkGray;

    protected abstract string WonMessage { get; }
    protected abstract string LoseMessage { get; }
    protected abstract string MoreMessage { get; }
    protected abstract string LessMessage { get; }
    
    public virtual void PrintWon()
    {
        PrintColored(WonMessage, WinColor);
    }

    public virtual void PrintLose()
    {
        PrintColored(LoseMessage, LoseColor);
    }

    public virtual void PrintMore()
    {
        Console.WriteLine(MoreMessage);
    }

    public virtual void PrintLess()
    {
        Console.WriteLine(LessMessage);
    }

    private void PrintColored(string message, ConsoleColor foreground)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = BackgroundColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public virtual void PrintLose(int goal)                                                                                                                                                                                                     
    {                                                                                                                                                                                                                                           
        Console.ForegroundColor = LoseColor;                                                                                                                                                                                                    
        Console.BackgroundColor = BackgroundColor;                                                                                                                                                                                              
        Console.WriteLine($"{LoseMessage} The number was: {goal}");
        Console.ResetColor();                                                                                                                                                                                                                   
    }
}