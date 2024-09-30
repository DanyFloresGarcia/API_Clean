using Domain.ModalidadesPagos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class ModalidadPagoConfiguration : IEntityTypeConfiguration<ModalidadPago>{
    public void Configure(EntityTypeBuilder<ModalidadPago> builder){
        builder.ToTable("ModalidadPago", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.HasIndex(e => e.id);
        builder.Property(d => d.id)
           .ValueGeneratedOnAdd();

        builder.HasIndex(e => e.plataformaId);
           
        builder.HasOne(d => d.plataforma)
               .WithMany()
               .HasForeignKey(d => d.plataformaId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}