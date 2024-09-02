using Domain.Prestamo;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo2>{
    public void Configure(EntityTypeBuilder<Prestamo2> builder){
        builder.ToTable("Prestamos");
        builder.HasKey(c=> c.id);
        builder.Property(c=> c.id).HasConversion(
            PrestamoId => PrestamoId.Value,
            value => new PrestamoId(value));
        //builder.Property(c=> c.id).HasMaxLength(50);
        // builder.Property(c=> c.lastName).HasMaxLength(50);
        // builder.Ignore(c=> c.FullName);
        // builder.Property(c=> c.Email).HasMaxLength(255);
        // builder.HasIndex(c=> c.Email).IsUnique();
        // builder.Property(c=> c.PhoneNumber).HasConversion(
        //     phoneNumber => phoneNumber.Value,
        //     value => PhoneNumber.Create(value)!)
        //     .HasMaxLength(9);
        // builder.OwnsOne(c=> c.Address, addressBuilder =>{
        //     addressBuilder.Property(a=> a.Country).HasMaxLength(3);
        //     addressBuilder.Property(a=> a.Line1).HasMaxLength(20);
        //     addressBuilder.Property(a=> a.Line2).HasMaxLength(20).IsRequired(false);
        //     addressBuilder.Property(a=> a.City).HasMaxLength(40);
        //     addressBuilder.Property(a=> a.State).HasMaxLength(40);
        //     addressBuilder.Property(a=> a.ZipCode).HasMaxLength(10).IsRequired(false);
        // });
        // builder.Property(c=> c.Active);

    }
}