using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BLL.UnitOfWork;
using BlogApp.Model.DataModel;
using BlogApp.UI.Extensions;
using BlogApp.UI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IUnitOfWork _uow;
        IHttpContextAccessor _accessor;

        public UserController(IUnitOfWork uow, IHttpContextAccessor accessor)
        {
            _uow = uow;
            _accessor = accessor;
        }

        [TypeFilter(typeof(CustomAuthorization))]
        public IActionResult List()
        {
            var users = _uow.UserRepository.GetList(x => x.IsActive).OrderByDescending(x => x.CreateDate).ToList();

            return View(users);
        }
    }
}