using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyCookBook.Models;

namespace MyCookBook.Data
{
    public class CookBookContext : DbContext
    {
        public CookBookContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Cathegory> Cathegories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        //public DbSet<DishType> DishTypes { get; set; }
        //public DbSet<CookWare> CookWares { get; set; }
    }
}