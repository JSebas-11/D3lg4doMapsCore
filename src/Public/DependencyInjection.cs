using D3lg4doMaps.Core.Internal.Abstractions;
using D3lg4doMaps.Core.Internal.Factories;
using D3lg4doMaps.Core.Internal.Http.Builders;
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
        // CONFIGURATION
        if (string.IsNullOrWhiteSpace(config.ApiKey))
            throw new ArgumentNullException(nameof(config), "ApiKey must be provided in MapsConfiguration.");
        
        config.BaseUrl = "";
        services.AddSingleton(config);

        // HTTP
        services.AddHttpClient<IMapsApiClient, MapsApiClient>();

        // UTILS
        services.AddSingleton<IMapsJsonSerializer, MapsJsonSerializer>();

        // BUILDERS
        services.AddTransient<IMapsUriBuilder, MapsUriBuilder>();
        services.AddTransient<IRequestBuilder, RequestBuilder>();

        // FACTORIES
        services.AddScoped<IRequestFactory, RequestFactory>();
        
        return services;
    }
}