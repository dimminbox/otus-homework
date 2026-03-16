using System.Diagnostics;

namespace Async_Await;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Reading files:");
        await ReadFilesAsync();
        
        Console.WriteLine("\nReading files in directory:");
        await ReadDirectoryAsync("files");
    }

    static async Task ReadFilesAsync()
    {
        var reader = new FileReader();

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var task1 = reader.GetCountSpacesInFile("1.txt");
        var task2 = reader.GetCountSpacesInFile("2.txt");
        var task3 = reader.GetCountSpacesInFile("3.txt");
        int[] results = await Task.WhenAll(task1, task2, task3);
        foreach (int result in results)
        {
            Console.WriteLine($"Spaces in file: {result}");
        }

        stopwatch.Stop();
        Console.WriteLine($"time is {stopwatch.ElapsedMilliseconds} ms.");
    }

    static async Task ReadDirectoryAsync(string directory)
    {
        var reader = new FileReader();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await reader.GetCountSpacesInDirectory("files");
        stopwatch.Stop();
        Console.WriteLine($"time is {stopwatch.ElapsedMilliseconds} ms.");
    }
}