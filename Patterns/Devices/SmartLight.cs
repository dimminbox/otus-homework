using Patterns.Abstractions;

namespace Patterns.Devices;

//умный фонарик наследует класс умное устройство
public class SmartLight : SmartDevice, IMyCloneable<SmartLight>, ICloneable
{
    public int Brightness { get; private set; }

    protected SmartLight(SmartDevice other, int brightness) : base(other)
    {
        Brightness = brightness;
    }

    public void SetBrightness(int value)
    {
        Brightness = value;
    }

    public SmartLight MyClone() => new (this, Brightness);

    public object Clone()
    {
        return MemberwiseClone();
    }
}