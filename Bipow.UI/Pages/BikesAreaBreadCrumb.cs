using Supercode.Blazor.BreadcrumbNavigation.Services;

namespace Bipow.UI.Pages;

public class BikesAreaBreadCrumb : Breadcrumb
{
    public override void Configure(BreadcrumbBuilder builder)
        => builder.Link("Bicicletas", "bikesarea");
}
