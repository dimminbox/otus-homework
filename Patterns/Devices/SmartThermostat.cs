using Patterns.Abstractions;

namespace Patterns.Devices;

//умный термометр наследует класс умное устройство
public class SmartThermostat : SmartDevice, IMyCloneable<SmartThermostat>, ICloneable
{
    public double Temperature { get; set; }

    protected SmartThermostat(SmartThermostat other, double temperature) : base(other)
    {
        Temperature = temperature;
    }
    public SmartThermostat()
    {
    }

    public void SetTemperature(double value)
    {
        Temperature = value;
    }

    public SmartThermostat MyClone() => new(this, Temperature);

    public object Clone()
    {
        return MemberwiseClone();
    }
}