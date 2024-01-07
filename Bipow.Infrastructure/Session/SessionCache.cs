using Blazored.SessionStorage;

namespace Bipow.Infrastructure.Session;

internal sealed class SessionCache(ISessionStorageService sessionStorageService) : ISessionCache
{
    private readonly ISessionStorageService _sessionStorageService = sessionStorageService;

    public async Task SetSessionKeyValueAsync<T>(string key, T value) =>
        await _sessionStorageService.SetItemAsync(key, value);
}
