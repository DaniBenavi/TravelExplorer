using Domain.Customers;
using Domain.TouristPackages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configuration;

public class TouristPackageConfiguration : IEntityTypeConfiguration<TouristPackage>
{

    public void Configure(EntityTypeBuilder<TouristPackage> builder)
    {

        builder.ToTable("TouristPackage");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            TouristPackageId => TouristPackageId.Value,
            value => new TouristPackageId(value)
        );

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.LineItems)
            .WithOne().HasForeignKey(li => li.TouristPackageId).IsRequired();
    }
}