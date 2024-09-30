using Domain.Plataformas;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class PlataformaConfiguration : IEntityTypeConfiguration<Plataforma>{
    public void Configure(EntityTypeBuilder<Plataforma> builder){
        builder.ToTable("Plataforma", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.Property(c => c.id)
           .ValueGeneratedOnAdd();

        builder.Property(c => c.nombre).IsUnicode();

    }
}