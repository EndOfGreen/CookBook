using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCookBook.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Private { get; set; }
        public string ImageLink { get; set; }
        public int CookTime { get; set; }
        public int CuisineId { get; set; }
        public int[] CathegoryId { get; set; }
        public int Volume { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public List<CookStep> Steps { get; set; } 
    }
}