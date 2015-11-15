using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
    public class CookStepsEditorController : Controller
    {
        //
        // GET: /CookStepsEditor/

        public ActionResult Index()
        {
            List<CookStep> cookSteps = new List<CookStep>();
            var cookStep0 = new CookStep() { Description = "TestDescription0", Comment = "TestComment0", Number = 1, RecipeId = 1 };
            var cookStep1 = new CookStep() { Description = "TestDescription1", Comment = "TestComment1", Number = 2, RecipeId = 1 };
            var cookStep2 = new CookStep() { Description = "TestDescription2", Comment = "TestComment2", Number = 3, RecipeId = 1 };
            cookSteps.Add(cookStep0);
            cookSteps.Add(cookStep1);
            cookSteps.Add(cookStep2);
            return View(cookStep0);
        }

        [HttpPost]
        public ActionResult Index(CookStep cookSteps)
        {
            var cc = cookSteps;
            return View(cc);
        }

        public ActionResult Indexs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Indexs(List<CookStep> cookSteps)
        {
            var cc = cookSteps;  
            return View();
        }

        public ActionResult Load()
        {
            List<CookStep> cookSteps = new List<CookStep>();
            var cookStep0 = new CookStep() { Description = "TestDescription0", Comment = "TestComment0", Number = 1, RecipeId = 1 };
            var cookStep1 = new CookStep() { Description = "TestDescription1", Comment = "TestComment1", Number = 2, RecipeId = 1 };
            var cookStep2 = new CookStep() { Description = "TestDescription2", Comment = "TestComment2", Number = 3, RecipeId = 1 };
            cookSteps.Add(cookStep0);
            cookSteps.Add(cookStep1);
            cookSteps.Add(cookStep2);
            Dictionary<string, object> dic = new Dictionary<string,object>();
            dic.Add("cookSteps",cookSteps);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

    }
}
