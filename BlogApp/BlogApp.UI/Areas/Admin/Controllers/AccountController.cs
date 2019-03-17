using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BLL.UnitOfWork;
using BlogApp.Model.DataModel;
using BlogApp.Model.ViewModel;
using BlogApp.UI.Extensions;
using BlogApp.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        IUnitOfWork _uow;
        IHttpContextAccessor _accessor;

        public AccountController(IUnitOfWork uow, IHttpContextAccessor accessor)
        {
            _uow = uow;
            _accessor = accessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(RedirectToRequestUrl))]
        public IActionResult Login(VMAccountLogin model)
        {
            User user = _uow.UserRepository.Get(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                TempData["ProcessResult"] = "Email address or password is incorrect!";
                TempData["AlertType"] = "warning";
                return View();
            }

            _accessor.HttpContext.Session.SetObject("loggedUser", user);
            return RedirectToAction("List","User"); 
        }
    }
}