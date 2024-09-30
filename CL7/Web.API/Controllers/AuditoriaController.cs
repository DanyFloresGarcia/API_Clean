using Application.Auditorias.Crear;
using Application.Auditorias.Listar;
using Domain.Auditorias;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Web.API.Controllers;

[Route("auditoria")]
public class Auditoria : ApiController
{
    private readonly ISender _mediator;

    public Auditoria(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearAuditoriaCommand command)
    {
        var createAuditoriaResult = await _mediator.Send(command);

        return createAuditoriaResult.Match(
            auditoria => Ok(),
            errors => Problem(errors)
        );
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAuditoriasAsync()
    {
        var auditoriasResult = await _mediator.Send(new ObtenerAuditoriasQuery());

        return auditoriasResult.Match(
            auditorias => Ok(auditorias),
            errors => Problem(errors)
        );
    }

    //[HttpGet("{usuarioCreadorId}")]
    //public async Task<IActionResult> GetAllAuditoriasForUser(int usuarioCreadorId)
    //{
    //    var auditoriasResult = await _mediator.Send(new ObtenerAuditoriasQuery());

    //    return auditoriasResult.Match(
    //        auditorias => Ok(auditorias),
    //        errors => Problem(errors)
    //    );
    //}
}

