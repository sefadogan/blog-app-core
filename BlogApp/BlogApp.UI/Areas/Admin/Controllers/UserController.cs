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
    [TypeFilter(typeof(CustomAuthorization))]
    public class UserController : Controller
    {
        readonly IUnitOfWork _uow;
        readonly IHttpContextAccessor _accessor;

        public UserController(IUnitOfWork uow, IHttpContextAccessor accessor)
        {
            _uow = uow;
            _accessor = accessor;
        }

        public IActionResult List()
        {
            var users = _uow.UserRepository.GetList(x => x.IsActive).OrderByDescending(x => x.CreateDate).ToList();

            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var user = _uow.UserRepository.Get(x => x.UserId == id);
            if (user == null)
            {
                TempData["ProcessResult"] = "There is no such user.";
                TempData["AlertType"] = "warning";
                return RedirectToAction("List");
            }

            _accessor.HttpContext.Session.SetObject("selectedUser", user); // Post metodunda yakalamak adına oluşturuldu.
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            var result = _uow.UserRepository.Add(model);
            if (!_uow.Commit())
            {
                TempData["ProcessResult"] = "An unexpected error has occured while creating user.";
                TempData["AlertType"] = "danger";
                return RedirectToAction("List");
            }

            TempData["ProcessResult"] = "User created successfully.";
            TempData["AlertType"] = "success";
            return View();
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            User user = _accessor.HttpContext.Session.GetObject<User>("selectedUser");
            user = model; // userId?

            var result = _uow.UserRepository.Update(user);
            if(!_uow.Commit())
            {
                TempData["ProcessResult"] = "An unexpected error has occured while updating user.";
                TempData["AlertType"] = "danger";
            }

            HttpContext.Session.Remove("selectedUser");
            TempData["ProcessResult"] = "User updated successfully.";
            TempData["AlertType"] = "success";

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var result = _uow.UserRepository.Delete(id);
            if (!_uow.Commit())
            {
                TempData["ProcessResult"] = "An unexpected error has occured while deleting user.";
                TempData["AlertType"] = "danger";
            }

            TempData["ProcessResult"] = "User deleted successfully.";
            TempData["AlertType"] = "success";

            return RedirectToAction("List");
        }
    }
}