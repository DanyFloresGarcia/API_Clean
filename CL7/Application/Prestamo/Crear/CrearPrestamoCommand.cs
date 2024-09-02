using ErrorOr;
using MediatR;

namespace Application.Prestamo.Crear;

public record CrearPrestamoCommand(
    int  SolicitudId,
    int  EstadoId,
    DateTime FechaPrestamo,
    //bool Active,
    int UsuarioCreadorId
    //DateTime FechaCreacion,
    //string HostCreador
) : IRequest<ErrorOr<Unit>>;

