using System;
using System.Collections.Generic;
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
        public IEnumerable<string> GetCuisines()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cuisine/5
        public string GetCuisine(int id)
        {
            return "value";
        }

        // POST api/cuisine
        [HttpPost]
        public bool PostCuisine([FromBody]string value)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Cuisine>(value);
                db.Cuisines.Add(model);
                db.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }


        }

        // PUT api/cuisine/5            
        public bool PutCuisine([FromBody]string value)
        {
            try
            {

                Cuisine model = JsonConvert.DeserializeObject<Cuisine>(value);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        // DELETE api/cuisine/5
        public int DeleteCuisine([FromBody]int id)
        {
            try
            {
                Cuisine cuisine = db.Cuisines.Find(id);
                db.Cuisines.Remove(cuisine);
                db.SaveChanges();
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
