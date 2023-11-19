using Bipow.Domain.Entities.Menus;
using Bipow.Domain.Entities.UserAccount;
using Microsoft.EntityFrameworkCore;

namespace Bipow.Core.DbContext;

public interface IdbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserBillingDetailsEntity> UserBillingDetails { get; set; }
    public DbSet<UserMetadataEntity> UserMetadata { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<NavMenusEntity> NavMenus { get; set; }
}
