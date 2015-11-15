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
    public class CathegoryEditController : Controller
    {
        private CookBookContext db = new CookBookContext();

        //
        // GET: /CathegoryEdit/

        public ActionResult Index()
        {
            return View(db.Cathegories.ToList());
        }

        //
        // GET: /CathegoryEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            Cathegory cathegory = db.Cathegories.Find(id);
            if (cathegory == null)
            {
                return HttpNotFound();
            }
            return View(cathegory);
        }

        //
        // GET: /CathegoryEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CathegoryEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cathegory cathegory)
        {
            if (ModelState.IsValid)
            {
                db.Cathegories.Add(cathegory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cathegory);
        }

        //
        // GET: /CathegoryEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cathegory cathegory = db.Cathegories.Find(id);
            if (cathegory == null)
            {
                return HttpNotFound();
            }
            return View(cathegory);
        }

        //
        // POST: /CathegoryEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cathegory cathegory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cathegory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cathegory);
        }

        //
        // GET: /CathegoryEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cathegory cathegory = db.Cathegories.Find(id);
            if (cathegory == null)
            {
                return HttpNotFound();
            }
            return View(cathegory);
        }

        //
        // POST: /CathegoryEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cathegory cathegory = db.Cathegories.Find(id);
            db.Cathegories.Remove(cathegory);
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