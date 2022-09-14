using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Dignite.Abp.AspNetCore.Mvc.UI.Theme.Pure.Bundling;

public class PureThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/pure/layout.css");
    }
}