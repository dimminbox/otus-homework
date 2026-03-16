using Patterns.Abstractions;

namespace Patterns.Devices;

//базовый класс устройство 
public class Device : IMyCloneable<Device>, ICloneable
{
    public string Name { get; set; }

    protected Device() {}
    protected Device(Device other)
    {
        Name = other.Name;
    }

    public virtual void TurnOn()
    {
        Console.WriteLine($"Turning on {Name}");
    }

    public virtual void TurnOff()
    {
        Console.WriteLine($"Turning off {Name}");
    }

    public virtual Device MyClone() => new Device(this);

    public object Clone()
    {
        return MemberwiseClone();
    }
}