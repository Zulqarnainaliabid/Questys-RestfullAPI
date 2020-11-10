using Microsoft.Extensions.Logging;
using Questys.RestfullAPI.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;

namespace Questys.RestfullAPI.Repository.HttpApi
{
    public abstract class BaseRepositoryController : AbpController
    {
        #region Private members
        protected readonly ILogger<BaseRepositoryController> _logger;
        #endregion
        protected BaseRepositoryController(ILogger<BaseRepositoryController> logger)
        {
            _logger = logger;

            LocalizationResource = typeof(RepositoryResource);
        }
        #region Constructors

        #endregion
    }
}
