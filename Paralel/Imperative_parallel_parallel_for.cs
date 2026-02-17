namespace Paralel;

public class Imperative_parallel_parallel_for : ICalc
{
    public long Calc(int[] numbers)
    {
        long totalSum = 0;
        Parallel.For(0, numbers.Length, () => 0, (i, _, localSum) =>
            {
                localSum += numbers[i];
                return localSum;
            },
            localSum =>
            {
                Interlocked.Add(ref totalSum, localSum);
            });
        return totalSum;
    }
}