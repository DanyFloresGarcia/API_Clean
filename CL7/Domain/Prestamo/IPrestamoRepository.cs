using MediatR;

namespace Domain.Prestamo;

public interface IPrestamoRepository{
    void Add(Prestamo2 Prestamo);
}