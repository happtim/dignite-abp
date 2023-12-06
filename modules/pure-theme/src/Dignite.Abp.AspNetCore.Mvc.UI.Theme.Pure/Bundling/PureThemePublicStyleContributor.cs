using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Dignite.Abp.AspNetCore.Mvc.UI.Theme.Pure.Bundling;

public class PureThemePublicStyleContributor : BundleContributor
{    
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/pure/public.css");
    }
}
