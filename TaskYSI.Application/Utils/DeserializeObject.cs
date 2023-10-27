using System.Text.Json;

namespace TaskYSI.Application.Utils;

public static class DeserializeObject
{
    public static T DeserializeAnonymousType<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}