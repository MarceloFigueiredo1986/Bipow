using Bipow.Core.Repositories;
using Bipow.Core.UnitsOfWork;
using Bipow.Infrastructure.Database;
using Bipow.Infrastructure.Repositories;
using Bipow.Infrastructure.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Bipow.Infrastructure.Bootstrap;

public static class InstallServices
{
    public static IServiceCollection InstalInfraServices(this IServiceCollection services)
    {
        services.AddTransient<IUserUnitOfWork, UserUnitOfWork>();
        services.AddDbContextFactory<DatabaseContext>();
        services.AddTransient<IMenusRepository, MenusRepository>();

        return services;
    }
}
