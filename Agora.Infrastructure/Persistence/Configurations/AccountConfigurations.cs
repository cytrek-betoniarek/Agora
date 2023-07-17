using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agora.Domain.Account;

namespace Agora.Infrastructure.Persistence.Configurations;

internal class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        ConfigureAccountsTable(builder);
    }

    private void ConfigureAccountsTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id,
                value => value);

        builder.Property(a => a.Email)
            .HasMaxLength(100);

        builder.Property(a => a.FirstName)
            .HasMaxLength(100);

        builder.Property(a => a.LastName)
            .HasMaxLength(100);

        builder.Property(a => a.BirthDate)
            .HasConversion(
                  d => d,
                  v => v)
                .HasMaxLength(100);

        builder.Property(a => a.PasswordHash)
            .HasMaxLength(1000);

        builder.Property(a => a.Role)
            .HasMaxLength(30);
    }
}
