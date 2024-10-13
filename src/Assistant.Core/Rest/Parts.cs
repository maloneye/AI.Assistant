using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public record Parts
{
    [JsonPropertyName("text")]
    public string Text { get; }

    public Parts(string text)
    {
        Text = text;
    }
}
