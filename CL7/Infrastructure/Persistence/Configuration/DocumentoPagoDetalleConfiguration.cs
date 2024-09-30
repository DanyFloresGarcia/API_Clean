using Domain.DocumentosPagosDetalle;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class DocumentoPagoDetalleConfiguration : IEntityTypeConfiguration<DocumentoPagoDetalle>{
    public void Configure(EntityTypeBuilder<DocumentoPagoDetalle> builder){
        builder.ToTable("DocumentoPagoDetalle", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.HasIndex(e => e.id);
        builder.Property(d => d.id)
           .ValueGeneratedOnAdd();

        builder.HasIndex(e => e.documentoPagoId);
           
        builder.HasOne(d => d.documentoPago)
               .WithMany()
               .HasForeignKey(d => d.documentoPagoId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(d => d.monto).HasPrecision(18,2);
    }
}