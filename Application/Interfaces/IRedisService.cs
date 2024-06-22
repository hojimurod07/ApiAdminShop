namespace Application.Interfaces;

public interface IRedisService
{
    public Task DeleteAsync(string key);
    public Task<string?> GetAsync(string key);
    public Task SetAsync(string key, string value);
}
