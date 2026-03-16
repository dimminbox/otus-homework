namespace Patterns.Devices;

//умная устройство наследует класс устройтво
public class SmartDevice : Device
{
    public string IpAddress { get; set; }
    
    protected SmartDevice() {}
    
    public virtual void Connect()
    {
    }

    protected SmartDevice(SmartDevice other) : base(other)
    {
        IpAddress = other.IpAddress;
    }

    public override SmartDevice MyClone() => new SmartDevice(this);
}