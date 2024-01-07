using Bipow.Core.DbContext;
using Bipow.Domain.Entities.Menus;
using Bipow.Domain.Entities.UserAccount;
using Microsoft.EntityFrameworkCore;

namespace Bipow.Infrastructure.Database;

public sealed class DatabaseContext : DbContext , IdbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bipow;Trusted_Connection=True");

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserBillingDetailsEntity> UserBillingDetails { get; set; }
    public DbSet<UserMetadataEntity> UserMetadata { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<NavMenusEntity> NavMenus { get; set; }
    public DbSet<UsersByStoreEntity> UsersByStores { get; set; }

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

        modelBuilder.
            Entity<NavMenusEntity>().
            HasKey(b => b.NavMenuId).
            HasName("pk_navmenus_navmenuid");

        modelBuilder.
            Entity<UsersByStoreEntity>().
            HasKey(b => new { b.StoreId,b.UserId }).
            HasName("pk_usersbystore_usersbystoreid");

        modelBuilder.
    Entity<UsersByStoreEntity>().
    HasKey(b => new { b.StoreId, b.UserId }).
    HasName("pk_navmenus_navmenuid");
    }
}
