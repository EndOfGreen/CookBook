using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MyCookBook.Models;
using MyCookBook.Data;
using Newtonsoft.Json;
using System.Web.Http;

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

        [System.Web.Http.HttpPost]
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
        [System.Web.Http.HttpGet]
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

        /*[System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public bool Edit([FromBody]string data)
        {
            try
            {
                Cuisine model = JsonConvert.DeserializeObject<Cuisine>(data);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        */
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

        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
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

        [System.Web.Http.HttpPost]
        public string ImageUpload()
        {
            HttpPostedFileBase image = Request.Files["fileInput"];
            if (image != null)
            {
                string relativePath = "/Images/Cathegory/" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string physicalPath = Server.MapPath(relativePath);
                image.SaveAs(physicalPath);
                return relativePath;
            }
            return "Сбой загрузки файла";
        }
    }
}