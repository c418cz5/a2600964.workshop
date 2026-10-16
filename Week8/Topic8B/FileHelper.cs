using System.IO;
using System.Text.Json;

public class FileHelper
{
    public static void FileWriter<T>(string path, T objectToWrite) where T : class
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(objectToWrite, options);
        File.WriteAllText(path, jsonString);
    }

    public static T FileReader<T>(string path) where T : class
    {
        string jsonString = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }
}