using GameShare.Data;
using GameShare.Models;
using GameShare.Models.Game;
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
    public class GameController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Game
        public ActionResult Index()
        {
            var service = CreateGameService();
            var model = service.GetGames();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateGameService();
            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your game could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var details = service.GetGameById(id);
            var model = new GameEdit
            {
                GameId = details.GameId,
                Name = details.Name,
                GameConsole = details.GameConsole,
                ForRent = details.ForRent
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var service = CreateGameService();
            service.DeleteGame(id);
            TempData["SaveResult"] = "The Game has been deleted.";
            return RedirectToAction("Index");

        }

        private IGameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }
    }
}
