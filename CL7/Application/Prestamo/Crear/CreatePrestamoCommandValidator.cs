using FluentValidation;

namespace Application.Prestamo.Crear;

public class CreatePrestamoCommandValidator : AbstractValidator<CrearPrestamoCommand>
{
    public CreatePrestamoCommandValidator()
    {

        RuleFor(r => r.EstadoId).NotEqual(0)
             .WithName("Estado");
        RuleFor(r => r.SolicitudId).NotEqual(0)
             .WithName("Codigo de solicitud");
        RuleFor(r => r.FechaPrestamo).NotEmpty()
             .WithName("Fecha del Prestamo");
    }
}