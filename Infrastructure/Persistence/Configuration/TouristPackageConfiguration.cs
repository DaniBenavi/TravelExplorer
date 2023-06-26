using Domain.Customers;
using Domain.TouristPackages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TouristPackageConfiguration : IEntityTypeConfiguration<TouristPackage>
{

    public void Configure(EntityTypeBuilder<TouristPackage> builder)
    {
        builder.ToTable("TouristPackage");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            OrderId => OrderId.Value,
            value => new TouristPackageId(value)
        );

        builder.HasMany(o => o.LineItems)
            .WithOne()
            .HasForeignKey(li => li.TouristPackageId);

        builder.Property(li => li.Traveldate);
        builder.OwnsOne(li => li.Price);
    }
}