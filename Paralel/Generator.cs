namespace Paralel;

public static class Generator
{
    public static int[] Generate(int size)
    {
        var random = new Random();
        return Enumerable
            .Range(0, size)
            .Select(_ => random.Next(-100, 101))
            .ToArray();
    }
}