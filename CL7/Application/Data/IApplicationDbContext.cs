using Domain.Auditorias;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Auditoria> Auditorias { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}