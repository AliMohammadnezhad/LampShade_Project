﻿using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.FullName).HasMaxLength(150);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(150);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.RoleId);


        }
    }
}
