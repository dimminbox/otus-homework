using Patterns.Devices;
using Xunit;

namespace Patterns;

public class Test
{
    [Fact]
    public async Task Test1()
    {
        SmartCamera camera = new ()
        {
            IpAddress = "127.0.0.1",
            Name = "Private",
            IsRecording = true,
            Settings = new CameraSettings(30)
        };

        var cam1 = (SmartCamera)camera.Clone();
        var cam2 = camera.MyClone();

        camera.Settings.Fps = 100;

        Assert.Equal(camera.Settings, cam1.Settings);
        Assert.NotEqual(camera.Settings, cam2.Settings);
        Assert.NotEqual(cam1.Settings, cam2.Settings);
    }
    
    [Fact]
    public async Task Test2()
    {
        SmartThermostat thermostat = new ()
        {
            IpAddress = "127.0.0.1",
            Name = "Own",
            Temperature = 20
        };

        var thermostat1 = (SmartThermostat)thermostat.Clone();
        var thermostat2 = thermostat1.MyClone();
        Assert.NotEqual(thermostat1,  thermostat2);
    }
}