using Supercode.Blazor.BreadcrumbNavigation.Services;

namespace Bipow.UI;

public class IndexBreadcrumb : RootBreadcrumb
{
    public override void Configure(BreadcrumbBuilder builder)
        => builder.Link(string.Empty, string.Empty);
}