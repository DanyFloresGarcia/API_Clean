using Application.Data;
using Domain.Auditorias;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        services.AddPersistence(configuration);
        return services;
    }

     public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration){

        //EntityFramework
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        // Configuración de DapperContext
        services.AddSingleton<DapperContext>(sp =>
        new DapperContext(configuration.GetConnectionString("SqlServer")));
        

        //AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));
        
        services.AddScoped<IApplicationDbContext>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

        return services;
    }
}