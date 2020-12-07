using GameShare.Data;
using GameShare.Models.UserConsole;
using GameShare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShare.WebMVC.Controllers
{
    [Authorize]
    public class UserConsoleController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Game
        public ActionResult Index()
        {
            var service = CreateConsoleService();
            var model = service.GetUserConsoles();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserConsoleCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateConsoleService();
            if (service.CreateUserConsole(model))
            {
                TempData["SaveResult"] = "Your console was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your console could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateConsoleService();
            var model = service.GetUserConsoleById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateConsoleService();
            var details = service.GetUserConsoleById(id);
            var model = new UserConsoleEdit
            {
                ConsoleId = details.ConsoleId,
                Name = details.Name,
                ForRent = details.ForRent
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserConsoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConsoleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateConsoleService();

            if (service.UpdateUserConsole(model))
            {
                TempData["SaveResult"] = "Your console was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your console could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateConsoleService();
            var model = service.GetUserConsoleById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsole(int id)
        {
            var service = CreateConsoleService();
            service.DeleteUserConsole(id);
            TempData["SaveResult"] = "The Console has been deleted.";
            return RedirectToAction("Index");

        }

        private IUserConsoleService CreateConsoleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserConsoleService(userId);
            return service;
        }
    }
}