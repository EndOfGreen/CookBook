using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

namespace MyCookBook.Controllers
{
    public class Utill : ApiController
    {
        [System.Web.Http.HttpPost]
        public string PostCuisineImage()
        {
            var image = HttpContext.Current.Request.Files["fileInput"];
            if (image != null)
            {
                string relativePath = "/Images/Cathegory/" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string physicalPath = HttpContext.Current.Server.MapPath(relativePath);
                image.SaveAs(physicalPath);
                return relativePath;
            }
            return "Сбой загрузки файла";
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}