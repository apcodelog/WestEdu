using System;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Core.Models;

public static class Storage<T>
{
    private static JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static List<T> Read(string path)
    {
        try
        {
            if (!File.Exists(path)) return [];

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json, _options) ?? [];
        }
        catch (IOException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static void Write(string path, List<T> data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json);
        }
        catch (IOException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
