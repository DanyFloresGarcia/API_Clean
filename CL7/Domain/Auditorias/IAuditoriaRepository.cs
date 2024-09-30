using MediatR;

namespace Domain.Auditorias;

public interface IAuditoriaRepository{
    void Add(Auditoria auditoria);
    Task<List<Auditoria>> ObtenerAuditorias();
    Task<List<Auditoria>> ObtenerAuditoriasPorUsuario(int usuarioCreadorId);
}