using System.Diagnostics;

namespace Paralel;

public static class Runner
{
    public static void Start(ICalc calc, int size)
    {
        int[] arr = Generator.Generate(size);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        long sum = calc.Calc(arr);
        stopwatch.Stop();
        Console.WriteLine($"{calc.GetType()}, size {size}, time {stopwatch.ElapsedMilliseconds} ms, sum {sum}");
    }
}