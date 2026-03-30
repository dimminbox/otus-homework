namespace Solid.Options;

public record NumberSettings(int RetryCount, ValueRange<int> Range);

public readonly record struct ValueRange<T>(T Start, T End)
    where T : IComparable<T>
{
    public bool Contains(T value) =>
        value.CompareTo(Start) >= 0 && value.CompareTo(End) <= 0;
}