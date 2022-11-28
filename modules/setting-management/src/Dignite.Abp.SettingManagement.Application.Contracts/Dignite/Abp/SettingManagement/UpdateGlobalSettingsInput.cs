﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Dignite.Abp.SettingManagement;

public class UpdateGlobalSettingsInput : UpdateSettingsInput
{
    /// <summary>
    /// get global settings
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public override IReadOnlyList<SettingDto> GetSettings(ValidationContext validationContext)
    {
        var settingsAppService = validationContext.GetRequiredService<IGlobalSettingsAppService>();
        var settings = settingsAppService.GetListAsync(
            new GetSettingsInput { 
                GroupName=GroupName,
                SubGroupName=SubGroupName,
            }).Result;
        return settings.Items;
    }
}