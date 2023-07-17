using Agora.Domain.Account;
using Agora.Domain.Accounts;
using Agora.Domain.Discussion;
using Agora.Domain.Discussion.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Infrastructure.Persistence;

public class AgoraDBContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Discussion> Discussions { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Favourite> Favourites { get; set; } = null!;

    public AgoraDBContext(DbContextOptions<AgoraDBContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgoraDBContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().HasData(
            new Account
            (
                "admin@admin.admin",
                "CSTZout8CRHUDhGmHlYs9A==;Oc81Kk+WZuwIw7CXUGHsvk1jvSwHeunR1Berd87/ioY=",
                AccountRoles.Admin
            )
        );
    }
}
