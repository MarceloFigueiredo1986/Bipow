namespace Bipow.Infrastructure.Session;

public interface ISessionCache
{
   Task SetSessionKeyValueAsync<T>(string key, T value);
}
