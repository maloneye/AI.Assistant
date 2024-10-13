using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public class Content
{
    [JsonPropertyName("parts")]
    public IReadOnlyList<Parts> Parts { get; }

    [JsonPropertyName("role")]
    public string Role { get; }

    public Content(IEnumerable<Parts> parts, string role)
        : this(parts.ToList(), role)
    {
    }

    [JsonConstructor()]
    internal Content(IReadOnlyList<Parts> parts, string role)
    {
        Parts = parts;
        Role = role;
    }
}
