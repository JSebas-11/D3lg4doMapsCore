using System.Net.Http.Json;
using System.Text.Json;
using D3lg4doMaps.Core.Public.Abstractions;

namespace D3lg4doMaps.Core.Internal.Http.Client;

public class MapsApiClient : IMapsApiClient {
    // -------------------- INIT --------------------
    private readonly HttpClient _httpClient;
    private readonly IMapsJsonSerializer _serializer;

    public MapsApiClient(HttpClient httpClient, IMapsJsonSerializer serializer) {
        _httpClient = httpClient;
        _serializer = serializer;
    }

    // -------------------- METHS --------------------
    public async Task<T> GetAsync<T>(string endpoint, object? query = null) {
        var finalUrl = ""; //BuildUrl(url, query);
        var response = await _httpClient.GetAsync(finalUrl).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        return await DeserializeOrExceptionAsync<T>(response).ConfigureAwait(false);
    }

    public async Task<T> PostAsync<T>(string endpoint, object body) {
        var payload = JsonContent.Create(body);
        var response = await _httpClient.PostAsync(endpoint, payload).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        return await DeserializeOrExceptionAsync<T>(response).ConfigureAwait(false);
    }

    // -------------------- INNER METHS --------------------
    private async Task<T> DeserializeOrExceptionAsync<T>(HttpResponseMessage response) {
        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var result = _serializer.Deserialize<T>(json)
            ?? throw new JsonException($"Response could not be deserialize to type {typeof(T).Name}");

        return result;
    }
}