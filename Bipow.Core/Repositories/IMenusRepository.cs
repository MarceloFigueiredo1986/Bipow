using Bipow.Domain.Entities.Menus;

namespace Bipow.Core.Repositories;

public interface IMenusRepository
{
    IQueryable<NavMenusEntity> GetMenus(CancellationToken? cancellationToken);
}
