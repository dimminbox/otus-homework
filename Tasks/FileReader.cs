namespace Async_Await;

public class FileReader
{
    private const string pathFile = "files";

    public async Task<int> GetCountSpacesInFile(string filename)
    {
        int count = 0;
        var current = Directory.GetCurrentDirectory();

        var projectRoot = Path.Combine(current, "..", "..", "..");
        projectRoot = Path.GetFullPath(projectRoot);
        var path = Path.Combine(projectRoot, "files", filename);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {path} does not exist");
        }

        using (StreamReader reader = new StreamReader(path))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                count += line.Count(c => c == ' ');
            }
        }

        return count;
    }

    public async Task GetCountSpacesInDirectory(string directory)
    {
        string[] files;

        var current = Directory.GetCurrentDirectory();

        var projectRoot = Path.Combine(current, "..", "..", "..");
        projectRoot = Path.GetFullPath(projectRoot);
        var path = Path.Combine(projectRoot, directory);

        if (Directory.Exists(path))
        {
            files = Directory.GetFiles(path);
        }
        else
        {
            throw new DirectoryNotFoundException($"Directory {path} does not exist");
        }

        List<Task<int>> tasks = new();

        foreach (var file in files)
        {
            tasks.Add(Task.Run(async () =>
            {
                var result = await GetCountSpacesInFile(file);
                return result;
            }));
        }

        int[] results = await Task.WhenAll(tasks);
        foreach (var count in results)
        {
            Console.WriteLine($"Spaces in file: {count}");
        }
    }
}