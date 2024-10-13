using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public class UsageMetadata
{
    [JsonPropertyName("promptTokenCount")]
    public int PromptTokenCount { get; }

    [JsonPropertyName("candidatesTokenCount")]
    public int CandidatesTokenCount { get; }

    [JsonPropertyName("totalTokenCount")]
    public int TotalTokenCount { get; }

    public UsageMetadata(int promptTokenCount, int candidatesTokenCount, int totalTokenCount)
    {
        PromptTokenCount = promptTokenCount;
        CandidatesTokenCount = candidatesTokenCount;
        TotalTokenCount = totalTokenCount;
    }
}
