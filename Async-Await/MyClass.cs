namespace Async_Await;

public class MyClass
{
    public async Task<List<string>> GetDataAsync()
    {
        await Task.Delay(200);
        var data = new List<string>() { "0", "0", "0" };
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
        return data;
    }
    
    public async Task<List<string>> PrintDataAsync(List<string> data)
    {
        await Task.Delay(200);
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
        return data;
    }


}