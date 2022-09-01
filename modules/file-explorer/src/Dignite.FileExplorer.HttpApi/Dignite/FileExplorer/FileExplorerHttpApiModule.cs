﻿using Localization.Resources.AbpUi;
using Dignite.FileExplorer.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Dignite.FileExplorer;

[DependsOn(
    typeof(FileExplorerApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FileExplorerHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FileExplorerHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FileExplorerResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
