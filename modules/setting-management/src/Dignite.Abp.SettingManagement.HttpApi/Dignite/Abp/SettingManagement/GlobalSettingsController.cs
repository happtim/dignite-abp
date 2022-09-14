﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Dignite.Abp.SettingManagement;

[Area(SettingManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SettingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/setting-management/global-settings")]
public class GlobalSettingsController : AbpControllerBase, IGlobalSettingsAppService
{
    private readonly IGlobalSettingsAppService _globalSettingsAppService;

    public GlobalSettingsController(IGlobalSettingsAppService globalSettingsAppService)
    {
        _globalSettingsAppService = globalSettingsAppService;
    }

    [HttpGet]
    public async Task<ListResultDto<SettingGroupDto>> GetAllAsync()
    {
        return await _globalSettingsAppService.GetAllAsync();
    }

    [HttpPut]
    public async Task UpdateAsync(UpdateGlobalSettingsInput input)
    {
        await _globalSettingsAppService.UpdateAsync(input);
    }
}