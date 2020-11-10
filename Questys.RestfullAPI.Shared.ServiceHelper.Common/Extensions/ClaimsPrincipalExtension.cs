using System;
using System.Security.Claims;

namespace Questys.RestfullAPI.Shared.ServiceHelper.Common.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Get Preferred User name
        /// </summary>
        /// <param name="claimsPrincipal">ClaimsPrincipal</param>
        /// <returns>Preferred User name</returns>
        public static string GetPreferredUsername(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal?
                .FindFirst("preferred_username");

            return claim?.Value ?? string.Empty;
        }
    }

    public class RoleAttribute : Attribute
    {
        public RoleAttribute(params String[] roleNames)
        {
            ClaimsPrincipal user = new ClaimsPrincipal();
            foreach (String role in roleNames)
            {
                //if (!user.IsInRole(role))
                //    throw new UnauthorizedAccessException();
            }
        }
    }
}
