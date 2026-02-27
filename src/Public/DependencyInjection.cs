using D3lg4doMaps.Core.Internal.Http.Client;
using D3lg4doMaps.Core.Internal.Utils;
using D3lg4doMaps.Core.Public.Abstractions;
using D3lg4doMaps.Core.Public.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D3lg4doMaps.Core.Public;

public static class DependencyInjection {
    public static IServiceCollection AddD3lg4doMaps(
        this IServiceCollection services, MapsConfiguration config) 
    {
        if (string.IsNullOrWhiteSpace(config.ApiKey))
            throw new ArgumentNullException(nameof(config), "ApiKey must be provided in MapsConfiguration.");
        
        // HTTP
        services.AddHttpClient<IMapsApiClient, MapsApiClient>();

        // JSON
        services.AddSingleton<IMapsJsonSerializer, MapsJsonSerializer>();
        
        return services;
    }
}