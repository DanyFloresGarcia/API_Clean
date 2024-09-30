using Auditorias.Common;
using ErrorOr;
using MediatR;
namespace Application.Auditorias.Listar;

public record ObtenerAuditoriasQuery() : IRequest<ErrorOr<IReadOnlyList<AuditoriaResponse>>>;