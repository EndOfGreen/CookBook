using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MyCookBook.Models
{

    public class Cuisine
    {
        [Key]
        [Required]
        public int CuisineId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }

     public class Ingridient
     {
         [Key]
         public int IngridientId { get; set; }
         public string Name { get; set; }
         public string ImageLink { get; set; }
         public int Fat { get; set; }
         public int Сarbohydrates { get; set; }
         public int Proteins { get; set; }
         public int Сellulose { get; set; }
         public int EnergyValue { get; set; }
     }
     
    public class Cathegory
    {
        [Required]
        public int CathegoryId { get; set; }
        [Required]
        public string Name { get; set; } // первое второе салат итд + острое соленое сладкое
        public string ImageLink { get; set; }
    }

    
    public class CookWare
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
    }

    public class CookStep
    {
        [Key][Column(Order = 0)]
        public int Number { get; set; }
        [Key][Column(Order = 1)]
        public int RecipeId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}