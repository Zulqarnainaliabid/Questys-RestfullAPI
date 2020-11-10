using System;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Questys.RestfullAPI.Repository.Application.Contracts
{
    [DependsOn(
        //typeof(ServiceOrderDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class RepositoryApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<RepositoryApplicationContractsModule>("Questys.RestfullAPI.Repository.");
            });
        }
    }
}
