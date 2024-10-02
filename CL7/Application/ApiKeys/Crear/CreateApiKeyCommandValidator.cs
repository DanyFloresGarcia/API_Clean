using FluentValidation;

namespace Application.ApiKeys.Crear;

public class CreateApiKeyCommandValidator : AbstractValidator<CrearApiKeyCommand>
{
    public CreateApiKeyCommandValidator()
    {
        RuleFor(r => r.app).NotEmpty().MaximumLength(30).MinimumLength(5)
        .Matches("^[a-zA-Z0-9 ]*$")
        .WithMessage("El campo {PropertyName} solo puede contener letras, números y espacios.")
        .WithName("Nombre de la aplicación Pago");
    }
}