using Questys.RestfullAPI.Shared.ServiceHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questys.RestfullAPI.Shared.ServiceHelper.Implementation
{
    public class RepositoryService : BaseService, IRepositoryService
    {
        public string[] GetRepositories()
        {
            //Todo: must be given actuall implementation
            return new string[]{ "Questys","Test"};
        }
    }
}
