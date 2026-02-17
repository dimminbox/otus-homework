namespace Paralel;

public class Declarate_parallel_interlocked : ICalc
{
    public long Calc(int[] numbers)
    {
        int threadCount = 4;
        int chunkSize = numbers.Length / threadCount;
        long totalSum = 0;

        List<Thread> threads = new List<Thread>();
        for (int t = 0; t < threadCount; t++)
        {
            int start = t * chunkSize;
            int end = (t == threadCount - 1)
                ? numbers.Length
                : start + chunkSize;

            Thread thread = new Thread(() =>
            {
                long localSum = 0;

                for (int i = start; i < end; i++)
                    localSum += numbers[i];

                Interlocked.Add(ref totalSum, localSum);
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
            thread.Join();

        return totalSum;
    }
}