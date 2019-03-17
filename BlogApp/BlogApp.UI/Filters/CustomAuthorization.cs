using BlogApp.Model.DataModel;
using BlogApp.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.UI.Filters
{
    public class CustomAuthorization : IActionFilter
    {
        IHttpContextAccessor _accessor;

        public CustomAuthorization(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var loggedUser = _accessor.HttpContext.Session.GetObject<User>("loggedUser");
            if (loggedUser == null)
            {
                string requestUrl = _accessor.HttpContext?.Request?.GetDisplayUrl();
                _accessor.HttpContext.Session.SetString("requestUrl", requestUrl);
                context.Result = new RedirectResult("/Admin/Account/Login");
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
