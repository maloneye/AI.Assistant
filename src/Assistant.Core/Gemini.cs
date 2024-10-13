using Assistant.Core.Interfaces;
using Assistant.Core.Rest;
using System.Text;
using System.Text.Json;

namespace GeminiApiClient;
public class Gemini
{

    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private const string _baseUrl = "https://generativelanguage.googleapis.com";
    private const string _version = "v1beta";
    private const string _model = "gemini-1.5-flash-latest";
    private const string _job = "generateContent";

    public Gemini(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task<Response> SendRequestAsync(IGeminiRequest request)
    {
        var url = @$"{_baseUrl}/{_version}/models/{_model}:{_job}?key={_apiKey}";
        var json = request.ToJson();
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Gemini API returned an error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Response>(responseJson)
            ?? throw new NullReferenceException($"Failed to deserializer response:\n{responseJson}");
    }
}

