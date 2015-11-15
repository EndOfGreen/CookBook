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
    public class CuisineEditController : Controller
    {
        private CookBookContext db = new CookBookContext();

        //
        // GET: /CuisineEdit/

        public ActionResult Index()
        {
            return View(db.Cuisines.ToList());
        }

        //
        // GET: /CuisineEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            Cuisine cuisine = db.Cuisines.Find(id);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        //
        // GET: /CuisineEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CuisineEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                db.Cuisines.Add(cuisine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuisine);
        }

        //
        // GET: /CuisineEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cuisine cuisine = db.Cuisines.Find(id);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        //
        // POST: /CuisineEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuisine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuisine);
        }

        //
        // GET: /CuisineEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cuisine cuisine = db.Cuisines.Find(id);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        //
        // POST: /CuisineEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuisine cuisine = db.Cuisines.Find(id);
            db.Cuisines.Remove(cuisine);
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