using Domain.ApiKeys;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>{
    public void Configure(EntityTypeBuilder<ApiKey> builder){
        builder.ToTable("ApiKey", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.HasIndex(e => e.id);
        builder.Property(d => d.id)
           .ValueGeneratedOnAdd();

        builder.HasIndex(c=> c.app).IsUnique();
    }
}