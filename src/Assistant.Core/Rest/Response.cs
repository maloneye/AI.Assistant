using System.Text.Json.Serialization;

namespace Assistant.Core.Rest;
public class Response : IGeminiResponse
{
    [JsonPropertyName("candidates")]
    public IReadOnlyList<Candidate> Candidates { get; }

    [JsonPropertyName("usageMetadata")]
    public UsageMetadata UsageMetadata { get; }


    public Response(IEnumerable<Candidate> candidates, UsageMetadata usageMetadata)
        : this(candidates.ToList(), usageMetadata)
    {

    }

    [JsonConstructor()]
    internal Response(IReadOnlyList<Candidate> candidates, UsageMetadata usageMetadata)
    {
        Candidates = candidates;
        UsageMetadata = usageMetadata;
    }
}
