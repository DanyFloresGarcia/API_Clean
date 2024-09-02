using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Prestamo;

public sealed class Prestamo2 : AggregateRoot{
    
    public Prestamo2(PrestamoId Id, int SolicitudId, int EstadoId, DateTime FechaPrestamo, bool Active, int UsuarioCreadorId, DateTime FechaCreacion, string HostCreador)
    {
        id = Id;
        solicitudId = SolicitudId;
        estadoId = EstadoId;
        fechaPrestamo = FechaPrestamo;
        active = Active;
        usuarioCreadorId = UsuarioCreadorId;
        fechaCreacion = FechaCreacion;
        hostCreador = HostCreador;
    }

    private Prestamo2()
    {
        
    }

    public PrestamoId id { get; private set;}
    public int solicitudId {get; private set;} = 0;
    public int estadoId {get; private set;} = 0;
    public DateTime fechaPrestamo {get; private set;} = DateTime.Now;
    public bool active {get; set;}
    public int usuarioCreadorId {get; set;}
    public DateTime fechaCreacion {get; set;}
    public string hostCreador {get; set;}
    // public int? usuarioActualizadorId {get; set;}
    // public DateTime? fechaActualizacion {get; set;}
    // public string? hostActualizador {get; set;}

}