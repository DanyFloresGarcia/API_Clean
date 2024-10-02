using Application.Data;
using Domain.Primitives;
using Domain.Auditorias;
using Domain.ApiKeys;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public readonly IPublisher _publiser;

    public ApplicationDbContext(DbContextOptions options, IPublisher publiser) : base(options)
    {
        _publiser = publiser ?? throw new ArgumentNullException(nameof(publiser));
    }

    public DbSet<Auditoria> Auditorias { get; set;}
    public DbSet<ApiKey> ApiKey { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()){
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
        .Select(e=> e.Entity)
        .Where(e=> e.GetDomainEvents().Any())
        .SelectMany(e=> e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach(var domainEvent in domainEvents){
            await _publiser.Publish(domainEvent, cancellationToken);
        }

        return result;

    }
}