using AccountManagement.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
   public class AddressMapping:IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Country).HasMaxLength(50).IsRequired();
            builder.Property(x => x.State).HasMaxLength(70).IsRequired();
            builder.Property(x => x.City).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FullAddress).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Account).WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.AccountId);
        }
    }
}
