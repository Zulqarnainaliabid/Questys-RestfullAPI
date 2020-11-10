using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questys.RestfullAPI.Repository.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Questys.RestfullAPI.Repository.HttpApi
{
    [RemoteService]
    [Route("api/[controller]")]
    //[Authorize(Policy = "serviceOrderAccess")]
    public class RepositoryController : BaseRepositoryController
    {

        private readonly IRepositoryAppService _repositoryAppService;

        public RepositoryController(IRepositoryAppService repositoryAppService,
            ILogger<RepositoryController> logger)
            : base(logger)
        {
            _repositoryAppService = repositoryAppService;
        }


        /// <summary>
        /// Test
        /// </summary>
        /// <returns>Hello World!</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
            return await Task.Run(() =>
                Ok("Hello World!"));
        }
    }
}
