// See https://aka.ms/new-console-template for more information

namespace Async_Await;

class Program
{
    static async Task Main(string[] args)
    {
        var myClass = new MyClass();
        myClass.GetDataAsync();
        await myClass.PrintDataAsync(new List<string>(){"1","2","3", "4"});
        
    }
}

