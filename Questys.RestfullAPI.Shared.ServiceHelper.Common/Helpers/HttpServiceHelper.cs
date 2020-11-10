using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questys.RestfullAPI.Shared.ServiceHelper.Common.Helpers
{
    public static class HttpServiceHelper
    {
        public static IHttpContextAccessor HttpContextAccessor { get; private set; }

        public static void SetHttpContextAccessorService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
    }
}
