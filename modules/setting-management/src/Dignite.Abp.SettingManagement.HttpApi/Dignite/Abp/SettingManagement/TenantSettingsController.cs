﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Dignite.Abp.SettingManagement;

[Area(SettingManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SettingManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/setting-management/tenant-settings")]
public class TenantSettingsController : AbpControllerBase, ITenantSettingsAppService
{
    private readonly ITenantSettingsAppService _tenantSettingsAppService;

    public TenantSettingsController(ITenantSettingsAppService tenantSettingsAppService)
    {
        _tenantSettingsAppService = tenantSettingsAppService;
    }

    [HttpGet]
    [Route("groups")]
    public async Task<ListResultDto<SettingGroupDto>> GetAllGroupsAsync()
    {
        return await _tenantSettingsAppService.GetAllGroupsAsync();
    }

    [HttpGet]
    public async Task<ListResultDto<SettingDto>> GetListAsync(GetSettingsInput input)
    {
        return await _tenantSettingsAppService.GetListAsync(input);
    }

    [HttpPut]
    public async Task UpdateAsync(UpdateTenantSettingsInput input)
    {
        await _tenantSettingsAppService.UpdateAsync(input);
    }
}