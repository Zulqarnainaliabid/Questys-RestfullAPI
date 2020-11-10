using Questys.RestfullAPI.Repository.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Questys.RestfullAPI.Repository.Application
{
    [DependsOn(
        //typeof(RepositoryDomainModule),
        typeof(RepositoryApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class RepositoryApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<RepositoryApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<RepositoryApplicationModule>(validate: true);
            });
        }
    }
}
