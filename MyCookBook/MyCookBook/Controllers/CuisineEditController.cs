using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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
        // GET: /CuisineEdit/Create
        [System.Web.Http.HttpGet]
        public ActionResult Create()
        {
            return View();
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpPost]
        public string PostCuisineImage()
        {
            HttpPostedFileBase image = Request.Files["fileInput"];
            if (image != null)
            {
                string relativePath = "/Images/Cuisine/" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string physicalPath = Server.MapPath(relativePath);
                image.SaveAs(physicalPath);
                return relativePath;
            }
            return "Сбой загрузки файла";
        }
    }
}