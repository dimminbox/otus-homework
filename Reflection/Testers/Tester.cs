using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using Reflection.Examples;

namespace Reflection.Testers;

public class Tester : ITester
{
    private const int retryCount = 100_000;

    public double MeasureSerialization(Action<F> action, F arg)
    {
        Console.WriteLine($"Count of measurements is {retryCount.ToString(CultureInfo.InvariantCulture)}");
        double time = 0;
        for (int i = 0; i < retryCount; i++)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action(arg);
            stopwatch.Stop();
            time += stopwatch.ElapsedMilliseconds;
        }

        return time / retryCount;
    }

    public double MeasureDeserialization(Action<string> action, string arg)
    {
        Console.WriteLine($"Count of measurements is {retryCount.ToString(CultureInfo.InvariantCulture)}");
        double time = 0;
        for (int i = 0; i < retryCount; i++)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action(arg);
            stopwatch.Stop();
            time += stopwatch.ElapsedMilliseconds;
        }

        return time / retryCount;
    }
}