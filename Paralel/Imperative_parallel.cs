namespace Paralel;

public class Imperative_parallel_thread : ICalc
{
    public long Calc(int[] numbers)
    {
        return numbers.AsParallel().Sum();
    }
}