using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Questys.RestfullAPI.Shared.ServiceHelper.Common.Helpers
{
    public class KeycloakRoleAuthorizationHandler : AuthorizationHandler<KeycloakRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, KeycloakRoleRequirement requirement)
        {
            if (UserHasRole(context, requirement.RoleName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        bool UserHasRole(AuthorizationHandlerContext context, String role)
        {
            ClaimsIdentity identity = context.User.Identity as ClaimsIdentity;
            if (identity == null)
                return false;

            Claim claim = identity?.FindFirst("resource_access");
            if (claim == null)
                return false;

            JObject access = JsonConvert.DeserializeObject(claim.Value) as JObject;
            if (access == null)
                return false;

            JObject questysAccess = access.Value<JObject>("questys-mobile-access");
            if (questysAccess == null)
                return false;

            JArray questysRoleList = questysAccess.Value<JArray>("roles");
            if (questysRoleList == null)
                return false;

            IEnumerable<String> questysRoles = questysRoleList.Values<String>();
            return (questysRoles != null) && questysRoles.Contains(role, StringComparer.OrdinalIgnoreCase);
        }
    }

    public class KeycloakRoleRequirement : IAuthorizationRequirement
    {
        public KeycloakRoleRequirement(String roleName)
        {
            RoleName = roleName;
        }

        public String RoleName;
    }
}
