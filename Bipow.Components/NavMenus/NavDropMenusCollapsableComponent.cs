using Bipow.Core.Repositories;
using Bipow.Domain.Entities.Menus;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Bipow.Components.NavMenus;

public class NavDropMenusCollapsableComponent : ComponentBase, IDisposable
{
    [Inject]
    public required IMenusRepository MenusRepository { get; set; }

    [Inject]
    public required NavigationManager NavMan { get; set; }

    [Inject]
    public required ILogger<NavDropMenusCollapsableComponent> Logger { get; set; }

    protected CancellationTokenSource cts = new();

    protected IEnumerable<NavMenusEntity>? _menus;

    public void Dispose()
    {
        cts.Cancel();
        cts.Dispose();
        _menus = null;
        Logger.LogInformation("Disposed");
    }

    protected override void OnInitialized()
    {
        try
        {
            var result = MenusRepository.GetMenus(cts.Token);
            _menus = result.AsEnumerable();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,nameof(OnInitialized));  
        }
    }
}
