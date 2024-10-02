using AutoMapper;
using Domain.Auditorias;
using Auditorias.Common;
using ErrorOr;
using MediatR;


namespace Application.Auditorias.Listar;


internal sealed class ObtenerAuditoriasQueryHandler : IRequestHandler<ObtenerAuditoriasQuery, ErrorOr<IReadOnlyList<AuditoriaResponse>>>
{
    private readonly IAuditoriaRepository _auditoriaRepository;
    private readonly IMapper _mapper;

    public ObtenerAuditoriasQueryHandler(IAuditoriaRepository auditoriaRepository, IMapper mapper)
    {
        _auditoriaRepository = auditoriaRepository;
        _mapper = mapper;
    }


    public async Task<ErrorOr<IReadOnlyList<AuditoriaResponse>>> Handle(ObtenerAuditoriasQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Auditoria> auditorias = await _auditoriaRepository.ObtenerAuditorias();

        var auditoriaResponses = _mapper.Map<List<AuditoriaResponse>>(auditorias);

        return auditoriaResponses;
    }
}
