using Patterns.Abstractions;

namespace Patterns.Devices;

//умная камера наследует класс умное устройство
public class SmartCamera : SmartDevice, IMyCloneable<SmartCamera>, ICloneable
{
    public bool IsRecording { get; set; }
    public CameraSettings Settings { get; set; }

    protected SmartCamera(SmartCamera other) : base(other)
    {
        IsRecording = other.IsRecording;
        Settings = new CameraSettings(other.Settings.Fps);
    }

    public SmartCamera()
    {
    }

    public void StartRecording()
    {
        IsRecording = true;
    }

    public void StopRecording()
    {
        IsRecording = false;
    }

    public SmartCamera MyClone() => new(this);

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class CameraSettings
{
    public CameraSettings(int fps)
    {
        Fps = fps;
    }

    public int Fps { get; set; }
}