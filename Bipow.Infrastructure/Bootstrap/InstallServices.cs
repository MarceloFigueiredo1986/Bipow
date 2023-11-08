using Bipow.Core.Database;
using Bipow.Core.UnitsOfWork;
using Bipow.Infrastructure.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Bipow.Infrastructure.Bootstrap;

public static class InstallServices
{
    public static IServiceCollection InstalInfraServices(this IServiceCollection services)
    {
        services.AddTransient<IUserUnitOfWork, UserUnitOfWork>();
        services.AddDbContextFactory<DatabaseContext>();

        return services;
    }
}
