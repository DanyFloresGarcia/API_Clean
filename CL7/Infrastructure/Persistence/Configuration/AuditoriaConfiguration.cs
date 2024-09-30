using Domain.Auditorias;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configuration;

public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>{
    public void Configure(EntityTypeBuilder<Auditoria> builder){
        builder.ToTable("Auditoria", "sch_gespago");
        builder.HasKey(c=> c.id);
        builder.HasIndex(e => e.id);
        builder.Property(d => d.id)
           .ValueGeneratedOnAdd();

        builder.HasIndex(e => e.documentoPagoId);
        builder.HasOne(d => d.documentoPago)
               .WithMany()
               .HasForeignKey(d => d.documentoPagoId)
               .OnDelete(DeleteBehavior.Cascade);

        //builder.Property(c=> c.id).HasMaxLength(50);
        // builder.HasIndex(c=> c.Email).IsUnique();
        // builder.Property(c=> c.PhoneNumber).HasConversion(
        //     phoneNumber => phoneNumber.Value,
        //     value => PhoneNumber.Create(value)!)
        //     .HasMaxLength(9);
        // builder.OwnsOne(c=> c.Address, addressBuilder =>{
        //     addressBuilder.Property(a=> a.Country).HasMaxLength(3);
        //     addressBuilder.Property(a=> a.Line1).HasMaxLength(20);
        // });
        // builder.Property(c=> c.Active);

    }
}