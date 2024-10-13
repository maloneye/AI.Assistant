using Assistant.Core.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public class SimpleRequest : IGeminiRequest
{
    [JsonPropertyName("contents")]
    public IReadOnlyCollection<Content> Contents { get; }

    public SimpleRequest(string text)
    {
        Contents = [new([new(text)], "")];
    }

    public string ToJson(bool writeIndented = false)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = writeIndented
        };

        return JsonSerializer.Serialize(this, options);
    }
}
