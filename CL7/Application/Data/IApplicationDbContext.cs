using Domain.Prestamo;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Prestamo2> Prestamos { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}