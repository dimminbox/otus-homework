using Reflection.Examples;

namespace Reflection.Testers;

public interface ITester
{
    double MeasureSerialization(Action<F> action, F arg);
    double MeasureDeserialization(Action<string> action, string arg);
}