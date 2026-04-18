using Newtonsoft.Json;
using Reflection.Examples;
using Reflection.Serializers;
using Reflection.Testers;

namespace Reflection;

public class Program
{
    public static void Main()
    {
        var tester = new Tester();
        var f = new F();
        var instance = f.Get();
        
        var strToDeserialize = @"{""i1"":1,""i2"":2,""i3"":3,""i4"":4,""i5"":5}";
        
        Action<F> serialize = a => { JsonConvert.SerializeObject(a); };
        Action<string> deserialize = a => { JsonConvert.DeserializeObject(a, typeof(F)); };

        var customSerialize = tester.MeasureSerialization(CustomSerializer.Serialize, instance);
        Console.WriteLine($"Custom serialization took on average {customSerialize} ms");
        Console.WriteLine();
        
        var customDeserialize = tester.MeasureDeserialization(CustomSerializer.Deserialize, strToDeserialize);
        Console.WriteLine($"Custom deserialization took on average {customDeserialize} ms");
        Console.WriteLine();
        
        var newtonSoftSerialize = tester.MeasureSerialization(serialize, instance);
        Console.WriteLine($"NewtonSoft serialization took on average {newtonSoftSerialize} ms");
        Console.WriteLine();
        
        var newtonSoftDeserialize = tester.MeasureDeserialization(deserialize, strToDeserialize);
        Console.WriteLine($"NewtonSoft deserialization took on average {newtonSoftDeserialize} ms");
        Console.WriteLine();
    }
}