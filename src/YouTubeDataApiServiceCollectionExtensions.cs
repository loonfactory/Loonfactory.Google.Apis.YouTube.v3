// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Captions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Loonfactory.Google.Apis.YouTube.V3;

public static class YouTubeDataApiServiceCollectionExtensions
{
    /// <summary>
    /// Adds YouTube data api services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static YouTubeDataApiBuilder AddYouTubeDataApiCore(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddScoped<IYouTubeHandlerProvider, YouTubeHandlerProvider>();
        return new YouTubeDataApiBuilder(services);
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApiCore(this IServiceCollection services, Action<YouTubeOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        var builder = services.AddYouTubeDataApiCore();
        services.Configure(configureOptions);
        return builder;
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApi(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        var builder = services.AddYouTubeDataApiCore();

        services.TryAddSingleton(TimeProvider.System);

        builder.AddAccessTokenProvider<HttpContextAccessTokenProvider>();
        builder.AddYouTubeCaptions<YouTubeCaptions, YouTubeCaptionHandler>();

        return builder;
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApi(this IServiceCollection services, Action<YouTubeOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        var builder = services.AddYouTubeDataApi();
        services.Configure(configureOptions);
        return builder;
    }

}