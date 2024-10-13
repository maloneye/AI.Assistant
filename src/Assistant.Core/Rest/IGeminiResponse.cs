namespace Assistant.Core.Rest;

public interface IGeminiResponse
{
    IReadOnlyList<Candidate> Candidates { get; }
    UsageMetadata UsageMetadata { get; }
}