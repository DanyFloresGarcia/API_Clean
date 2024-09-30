using Domain.Primitives;

namespace Domain.Plataformas;

public sealed class Plataforma : AggregateRoot{
    
    public Plataforma(int entidadBancariaId, string nombre)
    {
        this.entidadBancariaId = entidadBancariaId;
        this.nombre = nombre;
    }

    private Plataforma()
    {
        
    }

    public int id { get; private set;}
    public int entidadBancariaId { get; private set; }
    public string nombre  { get; private set; }

}