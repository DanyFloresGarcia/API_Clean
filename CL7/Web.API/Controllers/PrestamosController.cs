using Application.Prestamo.Crear;
using ErrorOr;
using  MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Web.API.Controllers;

[Route("prestamos")]
public class Prestamos : ApiController
{
    private readonly ISender _mediator;

    public Prestamos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearPrestamoCommand command)
    {
        var createPrestamoResult = await _mediator.Send(command);

        return createPrestamoResult.Match(
            prestamo => Ok(),
            errors => Problem(errors)
        );
    }

}
