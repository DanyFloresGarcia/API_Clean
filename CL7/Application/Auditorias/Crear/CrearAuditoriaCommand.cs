using ErrorOr;
using MediatR;

namespace Application.Auditorias.Crear;

public record CrearAuditoriaCommand(
    int documentoPagoId,
    string accion,
    string observacion,
    string resultado,
    int usuarioCreadorId,
    string hostCreador,
    string appCreador
) : IRequest<ErrorOr<Unit>>;