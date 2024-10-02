using Application.ApiKeys.Crear;
using Application.ApiKeys.ObtenerporKey;
using Domain.ApiKeys;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Web.API.Controllers;

[Route("apiKey")]
public class ApiKey : ApiController
{
    private readonly ISender _mediator;

    public ApiKey(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearApiKeyCommand command)
    {
        var createApiKeyResult = await _mediator.Send(command);

        return createApiKeyResult.Match(
            auditoria => Ok(),
            errors => Problem(errors)
        );
    }


    [HttpGet("{key}")]
    public async Task<IActionResult> ObtenerporKey(string key)
    {
        var apiKeyResult = await _mediator.Send(new ObtenerporKeyQuery(key));

        return apiKeyResult.Match(
            ApiKey => Ok(ApiKey),
            errors => Problem(errors)
        );
    }
}

