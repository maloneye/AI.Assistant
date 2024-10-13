using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;

public class SafetyRating
{
    [JsonPropertyName("category")]
    public string Category { get; }

    [JsonPropertyName("probability")]
    public string Probability { get; }

    public SafetyRating(string category, string probability)
    {
        Category = category;
        Probability = probability;
    }
}