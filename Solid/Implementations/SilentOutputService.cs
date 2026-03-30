namespace Solid.Implementations;

public class SilentOutputService : BaseOutputService
{
    protected override string WonMessage => string.Empty;
    protected override string LoseMessage => string.Empty;
    protected override string MoreMessage => string.Empty;
    protected override string LessMessage => string.Empty;

    public override void PrintWon() {}
    public override void PrintLose() {}
    public override void PrintMore() {}
    public override void PrintLess() {}
}