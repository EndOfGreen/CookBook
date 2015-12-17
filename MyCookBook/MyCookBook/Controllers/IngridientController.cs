using System;
using System.Collections.Generic;
using System.Web.Http;
using MyCookBook.Models;
using MyCookBook.Data;
using Newtonsoft.Json;
using System.Data.Entity;

namespace MyCookBook.Controllers
{
    public class IngridientController : ApiController
    {
        private CookBookContext db = new CookBookContext();

        // GET api/<controller>
        public IEnumerable<string> GetCathegories()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string GetCathegory(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public bool PostIngridient([FromBody]string value)
        {
            try
            {
                Ingridient model = JsonConvert.DeserializeObject<Ingridient>(value);
                db.Ingridients.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        public bool PutIngridient([FromBody]string value)
        {
            try
            {
                Ingridient model = JsonConvert.DeserializeObject<Ingridient>(value);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // DELETE api/<controller>/5
        public int DeleteIngridient([FromBody]int id)
        {
            try
            {
                Ingridient ingridient = db.Ingridients.Find(id);
                db.Ingridients.Remove(ingridient);
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