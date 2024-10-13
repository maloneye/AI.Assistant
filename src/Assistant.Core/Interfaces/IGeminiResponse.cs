using Assistant.Core.Rest;

namespace Assistant.Core.Interfaces;

public interface IGeminiResponse
{
    IReadOnlyList<Candidate> Candidates { get; }
    UsageMetadata UsageMetadata { get; }
}