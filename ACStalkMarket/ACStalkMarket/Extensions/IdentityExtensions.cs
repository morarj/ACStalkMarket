using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ACStalkMarket.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetPeopleId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PeopleId");

            return (String.IsNullOrWhiteSpace(claim.Value)) ? string.Empty : claim.Value;
        }
    }
}