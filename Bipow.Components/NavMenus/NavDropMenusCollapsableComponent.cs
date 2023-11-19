using Bipow.Core.Repositories;
using Microsoft.AspNetCore.Components;

namespace Bipow.Components.NavMenus;

public sealed class NavDropMenusCollapsableComponent : ComponentBase
{
    [Inject]
    public required IMenusRepository MenusRepository { get; set; }

}
