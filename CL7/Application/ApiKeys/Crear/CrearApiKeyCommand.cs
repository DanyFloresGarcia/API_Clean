using ErrorOr;
using MediatR;

namespace Application.ApiKeys.Crear;

public record CrearApiKeyCommand(
    string app
) : IRequest<ErrorOr<Unit>>;