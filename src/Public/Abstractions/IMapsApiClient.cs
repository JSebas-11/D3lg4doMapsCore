namespace D3lg4doMaps.Core.Public.Abstractions;

public interface IMapsApiClient {
    public Task<T> GetAsync<T>(string endpoint, object? query = null);
    public Task<T> PostAsync<T>(string endpoint, object payload);
}