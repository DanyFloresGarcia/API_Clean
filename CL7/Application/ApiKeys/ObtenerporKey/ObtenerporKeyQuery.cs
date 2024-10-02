using ApiKeys.Common;
using ErrorOr;
using MediatR;
namespace Application.ApiKeys.ObtenerporKey;

public record ObtenerporKeyQuery(string key) : IRequest<ErrorOr<ApiKeyResponse>>;