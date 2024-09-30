using Domain.Auditorias;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories;

public class AuditoriaRepository : IAuditoriaRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DapperContext _contextDapper;

    public AuditoriaRepository(ApplicationDbContext context, DapperContext contextDapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _contextDapper = contextDapper;
    }

    public void Add(Auditoria Auditoria) => _context.Auditorias.Add(Auditoria);


    public async Task<List<Auditoria>> ObtenerAuditorias()
    {
        using var connection = _contextDapper.CreateConnection();
        var auditorias = await connection.QueryAsync<Auditoria>("SELECT * FROM sch_gespago.Auditoria");
        return auditorias.ToList();
    }


    public async Task<List<Auditoria>> ObtenerAuditoriasPorUsuario(int usuarioCreadorId)
    {
        using var connection = _contextDapper.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@usuarioCreadorId", usuarioCreadorId, DbType.Int32);

        var auditorias = await connection.QueryAsync<Auditoria>(
            "ObtenerAuditoriaporUsuario",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return auditorias.ToList();
    }

}