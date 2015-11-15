using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCookBook.Models;
using MyCookBook.Data;

namespace MyCookBook.Controllers
{
    public class RecipeEditController : Controller
    {
        private CookBookContext db = new CookBookContext();

        //
        // GET: /RecipeEdit/

        public ActionResult Index()
        {
            //var recipes = db.Recipes.Include(r => r.RecipeId);
            return View();
        }

        //
        // GET: /RecipeEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // GET: /RecipeEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RecipeEdit/Create

        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.CathegoryId = new SelectList(db.Cathegories, "CathegoryId", "Name", recipe.CathegoryId);
            return View(recipe);
        }

        //
        // GET: /RecipeEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.CathegoryId = new SelectList(db.Cathegories, "CathegoryId", "Name", recipe.CathegoryId);
            return View(recipe);
        }

        //
        // POST: /RecipeEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.CathegoryId = new SelectList(db.Cathegories, "CathegoryId", "Name", recipe.CathegoryId);
            return View(recipe);
        }

        //
        // GET: /RecipeEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // POST: /RecipeEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}