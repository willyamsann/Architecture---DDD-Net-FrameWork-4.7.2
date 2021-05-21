﻿using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Arquitetura.UI.Web.Helpers
{
    public static class PermissionHelper
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidatePermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this MvcHtmlString value, string claimName, string claimValue) 
        {
            return ValidatePermission(claimName, claimValue);
        }

        public static string IfClaimShow(this MvcHtmlString page, string claimName, string claimValue)
        {
            return !ValidatePermission(claimName, claimValue) ? "disabled" : "";
        }

        public static bool ValidatePermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}