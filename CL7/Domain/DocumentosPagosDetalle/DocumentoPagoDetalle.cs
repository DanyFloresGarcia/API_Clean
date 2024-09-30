using Domain.DocumentosPagos;
using Domain.Primitives;

namespace Domain.DocumentosPagosDetalle;

public sealed class DocumentoPagoDetalle : AggregateRoot{
    
    public DocumentoPagoDetalle(int pagoMasivoDetalleId, int documentoPagoId, decimal monto)
    {
        this.pagoMasivoDetalleId = pagoMasivoDetalleId;
        this.documentoPagoId = documentoPagoId;
        this.monto = monto;
    }

    private DocumentoPagoDetalle()
    {
        
    }

    public int id { get; private set;}
    public int pagoMasivoDetalleId {get; private set;}
    public int documentoPagoId {get; private set;}
    public DocumentoPago documentoPago{get; private set;}
    public decimal monto { get; private set;}

}