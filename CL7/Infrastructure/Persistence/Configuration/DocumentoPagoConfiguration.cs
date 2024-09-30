using Domain.DocumentosPagos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class DocumentoPagoConfiguration : IEntityTypeConfiguration<DocumentoPago>{
    public void Configure(EntityTypeBuilder<DocumentoPago> builder){
        builder.ToTable("DocumentoPago", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.HasIndex(e => e.id);
        builder.Property(d => d.id)
           .ValueGeneratedOnAdd();

        builder.Ignore(d => d.documentoPagoDetalles);

    }
}