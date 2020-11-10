using Questys.RestfullAPI.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Questys.RestfullAPI.Repository.Application
{
    public abstract class BaseRepositoryAppService : ApplicationService
    {
        protected BaseRepositoryAppService()
        {
            LocalizationResource = typeof(RepositoryResource);
            ObjectMapperContext = typeof(RepositoryApplicationModule);
        }
    }
}
