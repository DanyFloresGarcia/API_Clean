using Domain.ApiKeys;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories;

public class ApiKeyRepository : IApiKeyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DapperContext _contextDapper;

    public ApiKeyRepository(ApplicationDbContext context, DapperContext contextDapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _contextDapper = contextDapper;
    }

    public void Add(ApiKey apiKey) => _context.ApiKey.Add(apiKey);


    public async Task<ApiKey> ObtenerApiKey(string key)
    {
        using var connection = _contextDapper.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@key", key, DbType.Int32);

        var apiKey = await connection.QueryFirstAsync<ApiKey>(
            "ObtenerAuditoriaporUsuario",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return apiKey;
    }

    public string GenerarKey()
    {
        return $"{Guid.NewGuid()}-{DateTime.UtcNow.Ticks}-{GenerateRandomString(8)}";
    }

    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }
        return new string(result);
    }



}