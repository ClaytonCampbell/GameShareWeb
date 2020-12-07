using GameShare.Data;
using GameShare.Models;
using GameShare.Models.Inventory;
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
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            var service = CreateInventoryService();
            var model = service.GetInventories();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateInventoryService();
            if (service.CreateInventory(model))
            {
                TempData["SaveResult"] = "Your inventory was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Inventory could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateInventoryService();
            var model = service.GetInventoryById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateInventoryService();
            var details = service.GetInventoryById(id);
            var model = new InventoryEdit
            {
                InventoryId = details.InventoryId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InventoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.UpdateInventory(model))
            {
                TempData["SaveResult"] = "Your inventory was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your inventory could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateInventoryService();
            var model = service.GetInventoryById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInventory(int id)
        {
            var service = CreateInventoryService();
            service.DeleteInventory(id);
            TempData["SaveResult"] = "The inventory has been deleted.";
            return RedirectToAction("Index");

        }

        private IInventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            return service;
        }
    }
}