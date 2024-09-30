using FluentValidation;

namespace Application.Auditorias.Crear;

public class CreateAuditoriaCommandValidator : AbstractValidator<CrearAuditoriaCommand>
{
    public CreateAuditoriaCommandValidator()
    {

        RuleFor(r => r.documentoPagoId).NotEqual(0)
             .WithName("Documento Pago");
        RuleFor(r => r.accion).NotEmpty().NotNull()
             .WithName("Acción");
        RuleFor(r => r.resultado).NotEmpty().NotNull()
             .WithName("resultado");
        RuleFor(r => r.usuarioCreadorId).NotEqual(0).NotNull()
             .WithName("Usuario Creador");
    }
}