using Assistant.Core.Rest;

namespace Assistant.Core.Interfaces;

public interface IGeminiRequest
{
    IReadOnlyCollection<Content> Contents { get; }

    public string ToJson(bool writeIndented = false);
}