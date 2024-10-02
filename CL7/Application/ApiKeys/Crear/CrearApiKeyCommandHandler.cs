using Domain.ApiKeys;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.ApiKeys.Crear;

internal sealed class CrearApiKeyCommandHandler : IRequestHandler<CrearApiKeyCommand, ErrorOr<Unit>>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CrearApiKeyCommandHandler(IApiKeyRepository apiKeyRepository, IUnitOfWork unitOfWork)
    {
        _apiKeyRepository = apiKeyRepository ?? throw new ArgumentNullException(nameof(apiKeyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CrearApiKeyCommand command, CancellationToken cancellationToken)
    {
        var apiKey = new ApiKey(
            _apiKeyRepository.GenerarKey(),
            command.app,
            DateTime.Now.AddMonths(3)
        );

        _apiKeyRepository.Add(apiKey);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
