using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Questys.RestfullAPI.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Questys.RestfullAPI.Repository.HttpApi
{
    [DependsOn(
        //typeof(ServiceOrderApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class RepositoryHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(RepositoryHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<RepositoryResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
