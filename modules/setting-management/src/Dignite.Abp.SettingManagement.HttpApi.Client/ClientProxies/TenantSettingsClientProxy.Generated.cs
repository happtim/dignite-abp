// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Dignite.Abp.SettingManagement;

// ReSharper disable once CheckNamespace
namespace Dignite.Abp.SettingManagement.ClientProxies
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(ITenantSettingsAppService), typeof(TenantSettingsClientProxy))]
    public partial class TenantSettingsClientProxy : ClientProxyBase<ITenantSettingsAppService>, ITenantSettingsAppService
    {
        public virtual async Task<ListResultDto<SettingNavigationDto>> GetAllAsync()
        {
            return await RequestAsync<ListResultDto<SettingNavigationDto>>(nameof(GetAllAsync));
        }

        public virtual async Task UpdateAsync(UpdateTenantSettingsInput input)
        {
            await RequestAsync(nameof(UpdateAsync), new ClientProxyRequestTypeValue
            {
                { typeof(UpdateTenantSettingsInput), input }
            });
        }
    }
}
