using Bipow.Domain.Entities.UserAccount;
using Microsoft.EntityFrameworkCore;

namespace Bipow.Core.Database;

public sealed class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bipow;Trusted_Connection=True");

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserBillingDetailsEntity> UserBillingDetails { get; set; }
    public DbSet<UserMetadataEntity> UserMetadata { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<UserEntity>().
            HasKey(b => b.UserId).
            HasName("pk_user_userId");

        modelBuilder.
            Entity<UserBillingDetailsEntity>().
            HasKey(b => b.UserBillingId).
            HasName("pk_userbilling_userbillingid");

        modelBuilder.
            Entity<UserAddressEntity>().
            HasKey(b => b.UserAddressId).
            HasName("pk_useraddress_useraddressid");

        modelBuilder.
            Entity<UserMetadataEntity>().
            HasKey(b => b.UserMetadataId).
            HasName("pk_usermetadata_useraddressid");

    }
}
