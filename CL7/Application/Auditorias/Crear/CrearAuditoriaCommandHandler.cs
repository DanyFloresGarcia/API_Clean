using Domain.Auditorias;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;

namespace Application.Auditorias.Crear;

internal sealed class CrearAuditoriaCommandHandler : IRequestHandler<CrearAuditoriaCommand, ErrorOr<Unit>>
{
    private readonly IAuditoriaRepository _auditoriaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearAuditoriaCommandHandler(IAuditoriaRepository auditoriaRepository, IUnitOfWork unitOfWork)
    {
        _auditoriaRepository = auditoriaRepository ?? throw new ArgumentNullException(nameof(auditoriaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CrearAuditoriaCommand command, CancellationToken cancellationToken)
    {

        var auditoria = new Auditoria(
            command.documentoPagoId,
            command.accion,
            DateTime.Now,
            command.observacion,
            command.resultado,
            command.usuarioCreadorId,
            command.hostCreador,
            command.appCreador
        );

        _auditoriaRepository.Add(auditoria);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
