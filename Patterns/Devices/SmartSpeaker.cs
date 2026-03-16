using Patterns.Abstractions;

namespace Patterns.Devices;

//умная колонка наследует класс умное устройство
public class SmartSpeaker : SmartDevice, IMyCloneable<SmartSpeaker>, ICloneable
{
    public int Volume { get; private set; }

    protected SmartSpeaker(SmartSpeaker other, int volume) : base(other)
    {
        Volume = volume;
    }

    public void SetVolume(int value)
    {
        Volume = Math.Clamp(value, 0, 100);
    }

    public void Play(string track)
    {
        Console.WriteLine($"Playing {track}");
    }

    public SmartSpeaker MyClone() => new(this, Volume);

    public object Clone()
    {
        return MemberwiseClone();
    }
}