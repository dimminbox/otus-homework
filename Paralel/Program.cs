namespace Paralel;

class Program
{
    static async Task Main(string[] args)
    {
        Runner.Start(new Sync(), 100_000);
        Runner.Start(new Sync(), 1_000_000);
        Runner.Start(new Sync(), 10_000_000);
        Console.WriteLine();
        
        Runner.Start(new Imperative_parallel_thread(), 100_000);
        Runner.Start(new Imperative_parallel_thread(), 1_000_000);
        Runner.Start(new Imperative_parallel_thread(), 10_000_000);
        Console.WriteLine();
        
        Runner.Start(new Imperative_parallel_parallel_for(), 100_000);
        Runner.Start(new Imperative_parallel_parallel_for(), 1_000_000);
        Runner.Start(new Imperative_parallel_parallel_for(), 10_000_000);
        Console.WriteLine();

        
        Runner.Start(new Declarate_parallel(), 100_000);
        Runner.Start(new Declarate_parallel(), 1_000_000);
        Runner.Start(new Declarate_parallel(), 10_000_000);
        Console.WriteLine();
        
        Runner.Start(new Declarate_parallel_interlocked(), 100_000);
        Runner.Start(new Declarate_parallel_interlocked(), 1_000_000);
        Runner.Start(new Declarate_parallel_interlocked(), 10_000_000);
        Console.WriteLine();
    }
}

