using Domain.Prestamo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PrestamoRepository : IPrestamoRepository
{
    private readonly ApplicationDbContext _context;

    public PrestamoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Prestamo2 Prestamo) => _context.Prestamos.Add(Prestamo);
}