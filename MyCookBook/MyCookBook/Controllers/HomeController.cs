using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MyCookBook.Data;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new CookBookContext();
            var querry = from c in context.Cuisines
                         orderby c.CuisineId
                         select c;
            ViewBag.Cuisines = querry.AsEnumerable<Cuisine>();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
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
