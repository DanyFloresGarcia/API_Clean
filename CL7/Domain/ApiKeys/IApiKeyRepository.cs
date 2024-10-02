namespace Domain.ApiKeys;

public interface IApiKeyRepository{
    void Add(ApiKey apiKey);
    Task<ApiKey> ObtenerApiKey(string key);
    string GenerarKey();
}