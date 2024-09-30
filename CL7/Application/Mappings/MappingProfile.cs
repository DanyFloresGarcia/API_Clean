using AutoMapper;
using Domain.Auditorias;
using Auditorias.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auditoria, AuditoriaResponse>();
    }
}
