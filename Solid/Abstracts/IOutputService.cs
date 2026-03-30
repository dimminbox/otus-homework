using Solid.Common;

namespace Solid.Abstracts;

public interface IOutputService
{
    void PrintWon();
    void PrintLose();
    void PrintLose(int goal);
    void PrintMore();
    void PrintLess();
}