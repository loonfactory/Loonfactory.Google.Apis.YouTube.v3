// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Http;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Provides the appropriate <see cref="IYouTubeHandler"/> instance for the request.
/// </summary>
public interface IYouTubeHandlerProvider
{
    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <typeparam name="T">The type of the handler, constrained to <see cref="IYouTubeHandler"/>.</typeparam>
    /// <returns>The handler instance.</returns>
    Task<T?> GetHandlerAsync<T>() where T : class, IYouTubeHandler;
}