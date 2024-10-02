using Domain.Primitives;

namespace Domain.ApiKeys;

public sealed class ApiKey : AggregateRoot{
    
    public ApiKey(string key, string app, DateTime fechaExpiracion)
    {
        this.key = key;
        this.app = app;
        this.fechaExpiracion = fechaExpiracion;
    }

    private ApiKey()
    {
        
    }
    
    public int id { get; set; }
    public string key { get; set; }
    public string app { get; set; }
    public bool activo { get; set; } = true;
    public DateTime fechaCreacion { get; set; } = DateTime.Now;
    public DateTime fechaExpiracion { get; set; }

}