using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RandomChat.Models;
using System;

namespace RandomChat.Attributes
{
    public class AuthorizeUser : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var customerID = context.HttpContext.Session.GetInt32(nameof(AppUser.UserID));
            if (!customerID.HasValue)
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }
    }
}
