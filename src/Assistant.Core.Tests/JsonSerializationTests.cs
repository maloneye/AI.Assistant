using Assistant.Core.Rest;
using FluentAssertions;
using System.Text.Json;

namespace Assistant.Core.Tests;

[TestClass]
public class JsonSerializationTests
{
    private const string _validContentReply = "{\"parts\":[{\"text\":\"test\"}],\"role\":\"test1\"}";
    private const string _validCandidateReply = "{\"content\":{\"parts\":[{\"text\":\"Excellent! I'm glad to hear the test passed. \\n\\nIs there anything else I can help you with? \\n\"}],\"role\":\"model\"},\"finishReason\":\"STOP\",\"index\":0,\"safetyRatings\":[{\"category\":\"HARM_CATEGORY_SEXUALLY_EXPLICIT\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_HATE_SPEECH\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_HARASSMENT\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_DANGEROUS_CONTENT\",\"probability\":\"NEGLIGIBLE\"}]}";
    private const string _validResponse = "{\"candidates\":[{\"content\":{\"parts\":[{\"text\":\"Excellent!I'mgladtohearthetestpassed.\\n\\nIsthereanythingelseIcanhelpyouwith?\\n\"}],\"role\":\"model\"},\"finishReason\":\"STOP\",\"index\":0,\"safetyRatings\":[{\"category\":\"HARM_CATEGORY_SEXUALLY_EXPLICIT\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_HATE_SPEECH\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_HARASSMENT\",\"probability\":\"NEGLIGIBLE\"},{\"category\":\"HARM_CATEGORY_DANGEROUS_CONTENT\",\"probability\":\"NEGLIGIBLE\"}]}],\"usageMetadata\":{\"promptTokenCount\":5,\"candidatesTokenCount\":23,\"totalTokenCount\":28}}";

    [TestMethod($"Ensuring that a {nameof(SimpleRequest)} serializes correctly")]
    public void T0()
    {
        // Arrange
        var text = "test request";
        var request = new SimpleRequest(text);

        // Act
        var json = request.ToJson();

        // Assert
        json.Should().NotBe(null);
        json.Should().Be($"{{\"contents\":[{{\"parts\":[{{\"text\":\"{text}\"}}],\"role\":\"\"}}]}}");
    }


    [TestMethod($"Given a valid response in json, then deserialise to {nameof(Response)} correctly")]
    public void T1()
    {
        // Arrange & Act
        var response = JsonSerializer.Deserialize<Response>(_validResponse);

        // Assert
        response.Should().NotBe(null);

    }

    [TestMethod($"Given a valid candidate reply in json, then deserialise to {nameof(Candidate)} correctly")]
    public void T2()
    {
        // Arrange & Act
        var response = JsonSerializer.Deserialize<Candidate>(_validCandidateReply);

        // Assert
        response.Should().NotBe(null);

    }

    [TestMethod($"Given a valid candidate reply in json, then deserialise to {nameof(Content)} correctly")]
    public void T3()
    {
        // Arrange 
        var expectedPart = new Parts("test");
        var expectedRole = "test1";

        // Act
        var response = JsonSerializer.Deserialize<Content>(_validContentReply);

        // Assert
        response.Should().NotBeNull();
        response?.Parts.Should().HaveCount(1);
        response?.Parts[0].Should().Be(expectedPart);
        response?.Role.Should().Be(expectedRole);
    }
}
