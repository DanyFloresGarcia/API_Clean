using Domain.DocumentosPagos;
using Domain.Primitives;

namespace Domain.Auditorias;

public sealed class Auditoria : AggregateRoot{
    
    public Auditoria(int documentoPagoId, string accion, DateTime fechaEnvio, string observacion, string resultado, int usuarioCreadorId, string hostCreador, string appCreador)
    {
        this.documentoPagoId = documentoPagoId;
        this.accion = accion;
        this.fechaEnvio = fechaEnvio;
        this.observacion = observacion;
        this.resultado = resultado;
        this.usuarioCreadorId = usuarioCreadorId;
        this.hostCreador = hostCreador;
        this.appCreador = appCreador;
    }

    private Auditoria()
    {
        
    }

    public int id { get; private set;}
    public int documentoPagoId {get; private set;}
    public DocumentoPago documentoPago{get; private set;}
    public string accion {get; private set;}
    public DateTime fechaEnvio { get; private set; }
    public string observacion {get; set;}
    public string resultado  {get; set;}
    public int usuarioCreadorId {get; set; }
    public DateTime fechaCreacion { get; private set; } = DateTime.Now;
    public string hostCreador {get; set;}
    public string appCreador {get; set;}

}