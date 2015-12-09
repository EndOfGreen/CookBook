using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;
using MyCookBook.Models;
using MyCookBook.Data;
using Newtonsoft.Json;
using System.Data.Entity;

namespace MyCookBook.Controllers
{
    public class CuisineController : ApiController
    {
        private CookBookContext db = new CookBookContext();
        // GET api/cuisine
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cuisine/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/cuisine
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Cuisine model = JsonConvert.DeserializeObject<Cuisine>(value);
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

        // PUT api/cuisine/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cuisine/5
        public void Delete(int id)
        {
        }
    }
}
