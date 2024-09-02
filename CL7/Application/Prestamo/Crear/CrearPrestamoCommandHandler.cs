using Domain.Prestamo;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Prestamo.Crear;

internal sealed class CrearPrestamoCommandHandler : IRequestHandler<CrearPrestamoCommand, ErrorOr<Unit>>
{
    private readonly IPrestamoRepository _prestamoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearPrestamoCommandHandler(IPrestamoRepository prestamoRepository, IUnitOfWork unitOfWork)
    {
        _prestamoRepository = prestamoRepository ?? throw new ArgumentNullException(nameof(prestamoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CrearPrestamoCommand command, CancellationToken cancellationToken)
    {

        var prestamo = new Prestamo2(
             new PrestamoId(Guid.NewGuid()),
            command.SolicitudId,
            command.EstadoId,
            command.FechaPrestamo,
            true,
            command.UsuarioCreadorId,
            DateTime.Now,
            "localhost"
        );

        _prestamoRepository.Add(prestamo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
