using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MyCookBook.Models;
using MyCookBook.Data;

namespace MyCookBook.Controllers
{
    public class IngridientEditController : Controller
    {
        private CookBookContext db = new CookBookContext();

        //
        // GET: /IngridientEdit/

        public ActionResult Index()
        {
            return View(db.Ingridients.ToList());
        }

        //
        // GET: /IngridientEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        //
        // GET: /IngridientEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IngridientEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingridient ingridient)
        {
            if (ModelState.IsValid)
            {
                db.Ingridients.Add(ingridient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingridient);
        }

        //
        // GET: /IngridientEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        //
        // GET: /IngridientEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            if (ingridient == null)
            {
                return HttpNotFound();
            }
            return View(ingridient);
        }

        //
        // POST: /IngridientEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingridient ingridient = db.Ingridients.Find(id);
            db.Ingridients.Remove(ingridient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        public string PostIngridientImage()
        {
            HttpPostedFileBase image = Request.Files["fileInput"];
            if (image != null)
            {
                string relativePath = "/Images/Ingridient/" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string physicalPath = Server.MapPath(relativePath);
                image.SaveAs(physicalPath);
                return relativePath;
            }
            return "Сбой загрузки файла";
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}