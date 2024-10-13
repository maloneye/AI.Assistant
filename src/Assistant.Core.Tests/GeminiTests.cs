using Assistant.Core.Rest;
using FluentAssertions;
using GeminiApiClient;
using Microsoft.Extensions.Configuration;

namespace Assistant.Core.Tests;

[TestClass]
public class GeminiTests
{
    private readonly string _apiKey;

    public GeminiTests()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<GeminiTests>()
                                               .Build();

        _apiKey = config["Gemini:apiKey"]
            ?? throw new NullReferenceException("Could not find user secret for Gemini api key");
    }

    [TestMethod($"Given a {nameof(SimpleRequest)} then the api should reply")]
    public async Task T0()
    {
        var model = new Gemini(_apiKey);

        var json = new SimpleRequest("say: Test Passed!");
        var result = await model.SendRequestAsync(json);

        Assert.IsNotNull(result);
        result.Candidates.Should().HaveCount(1);
        result.Candidates[0].Content.Parts.Should().HaveCount(1);
        result.Candidates[0].Content.Parts[0].Text.Should().Contain("Test Passed!");
    }


}
