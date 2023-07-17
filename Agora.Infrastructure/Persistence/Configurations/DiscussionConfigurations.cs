using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agora.Domain.Discussion;
using Microsoft.Extensions.Logging;

namespace Agora.Infrastructure.Persistence.Configurations;

internal class DiscussionConfigurations : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        ConfigureAccountsTable(builder);
        ConfigureCommentsTable(builder);
        ConfigureFavouritesTable(builder);
    }

    private void ConfigureAccountsTable(EntityTypeBuilder<Discussion> builder)
    {
        builder.ToTable("Discussions");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id,
                value => value);

        builder.Property(d => d.AuthorId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id,
                    value => value);

        builder.Property(d => d.Title)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(3000);

        builder.Property(d => d.CreationDate)
            .HasConversion(
                  d => d,
                  v => v)
            .HasMaxLength(100);
    }

    private void ConfigureCommentsTable(EntityTypeBuilder<Discussion> builder)
    {
        builder.OwnsMany(d => d.Comments, cb =>
        {
            cb.ToTable("Comments");

            cb.HasKey(cb => cb.Id);

            cb.Property(cb => cb.AuthorId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id,
                    value => value);

            cb.WithOwner().HasForeignKey("DiscussionId");

            cb.Property(cb => cb.Commentary)
                .HasMaxLength(100);

            cb.Property(cb => cb.CreationDate)
            .HasConversion(
                  d => d,
                  v => v)
                .HasMaxLength(100);
        });

        builder.Metadata.FindNavigation(nameof(Discussion.Comments))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureFavouritesTable(EntityTypeBuilder<Discussion> builder)
    {
        builder.OwnsMany(d => d.Favourites, fb =>
        {
            fb.ToTable("Favourites");

            fb.HasKey(cb => cb.Id);

            fb.Property(cb => cb.UserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id,
                    value => value);

            fb.WithOwner().HasForeignKey("DiscussionId");

            fb.Property(cb => cb.CreationDate)
            .HasConversion(
                  d => d,
                  v => v)
                .HasMaxLength(100);
        });

        builder.Metadata.FindNavigation(nameof(Discussion.Favourites))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
