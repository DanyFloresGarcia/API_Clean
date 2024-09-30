using Domain.Plataformas;
using Domain.Primitives;

namespace Domain.ModalidadesPagos;

public sealed class ModalidadPago : AggregateRoot{
    
    public ModalidadPago(int plataformaId, int version, string ruta, string formato)
    {
        this.plataformaId = plataformaId;
        this.version = version;
        this.ruta = ruta;
        this.formato = formato;
    }

    private ModalidadPago()
    {
        
    }

    public int id { get; private set;}
    public int plataformaId {get; private set;}
    
    public Plataforma plataforma {get; private set;}
    public int version {get; private set;}
    public bool activo {get; private set;} = true;
    public string ruta {get; private set;}
    public string formato {get; private set;}

}