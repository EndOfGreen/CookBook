using System;
using System.Collections.Generic;
using System.Web.Http;
using MyCookBook.Models;
using MyCookBook.Data;
using Newtonsoft.Json;
using System.Data.Entity;

namespace MyCookBook.Controllers
{
    public class CathegoryController : ApiController
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
        public bool PostCathegory([FromBody]string value)
        {
            try
            {
                Cathegory model = JsonConvert.DeserializeObject<Cathegory>(value);
                db.Cathegories.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        public bool PutCathegory([FromBody]string value)
        {
            try
            {
                Cathegory model = JsonConvert.DeserializeObject<Cathegory>(value);
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
        public int DeleteCathegory([FromBody]int id)
        {
            try
            {
                Cathegory cathegory = db.Cathegories.Find(id);
                db.Cathegories.Remove(cathegory);
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