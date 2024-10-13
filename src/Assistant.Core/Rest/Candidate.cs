using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public class Candidate
{
    [JsonPropertyName("content")]
    public Content Content { get; }

    [JsonPropertyName("finishReason")]
    public string FinishReason { get; }

    [JsonPropertyName("index")]
    public int Index { get; }

    [JsonPropertyName("safetyRatings")]
    public IReadOnlyList<SafetyRating> SafetyRatings { get; }

    public Candidate(Content content, string finishReason, int index, IEnumerable<SafetyRating> safetyRatings)
            : this(content, finishReason, index, safetyRatings.ToList())
    {
    }

    [JsonConstructor()]
    internal Candidate(Content content, string finishReason, int index, IReadOnlyList<SafetyRating> safetyRatings)
    {
        Content = content;
        FinishReason = finishReason;
        Index = index;
        SafetyRatings = safetyRatings.ToList();
    }

}
