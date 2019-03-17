using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.UI.Filters
{
    public class RedirectToRequestUrl : IActionFilter
    {
        IHttpContextAccessor _accessor;

        public RedirectToRequestUrl(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string requestUrl = _accessor.HttpContext.Session.GetString("requestUrl");
            if (requestUrl == null)
                context.Result = new RedirectResult("/Admin/Account/Login");

            context.Result = new RedirectResult(requestUrl);
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
