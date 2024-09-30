using Domain.DocumentosPagosDetalle;
using Domain.Primitives;

namespace Domain.DocumentosPagos;

public sealed class DocumentoPago : AggregateRoot{
    
    public DocumentoPago(int pagoMasivoId)
    {
        this.pagoMasivoId = pagoMasivoId;
    }

    private DocumentoPago()
    {
        
    }

    public int id { get; private set;}
    public int pagoMasivoId {get; private set;}
    public List<DocumentoPagoDetalle> documentoPagoDetalles {get; private set;}

}