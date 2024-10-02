using AutoMapper;
using Domain.ApiKeys;
using ApiKeys.Common;
using ErrorOr;
using MediatR;


namespace Application.ApiKeys.ObtenerporKey;


internal sealed class ObtenerporKeyQueryHandler : IRequestHandler<ObtenerporKeyQuery, ErrorOr<ApiKeyResponse>>
{
    private readonly IApiKeyRepository _apiKeyRepository;
    private readonly IMapper _mapper;

    public ObtenerporKeyQueryHandler(IApiKeyRepository apiKeyRepository, IMapper mapper)
    {
        _apiKeyRepository = apiKeyRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ApiKeyResponse>> Handle(ObtenerporKeyQuery query, CancellationToken cancellationToken)
    {
        ApiKey apiKey = await _apiKeyRepository.ObtenerApiKey(query.key);

        var apiKeyResponse = _mapper.Map<ApiKeyResponse>(apiKey);

        return apiKeyResponse;
    }
}
