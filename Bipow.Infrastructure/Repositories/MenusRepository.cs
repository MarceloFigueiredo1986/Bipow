using Bipow.Core.DbContext;
using Bipow.Core.Repositories;
using Bipow.Domain.Entities.Menus;

namespace Bipow.Infrastructure.Repositories;

public sealed class MenusRepository : IMenusRepository
{
    private readonly IdbContext _dbContext;

    public MenusRepository(IdbContext dbContext) =>
        _dbContext = dbContext;

    public IQueryable<NavMenusEntity> GetMenus(CancellationToken? cancellationToken)
        => _dbContext.NavMenus.AsQueryable();

}
