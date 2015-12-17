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
        public int? CuisineId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(AutoGenerateField = false)]
        public string ImageLink { get; set; }
    }

     public class Ingridient
     {
        [Key]
        [Required]
        public int? IngridientId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(AutoGenerateField = false)]
        public string ImageLink { get; set; }
        [Required]
        [Display(Name = "Жиры")]
        public int Fat { get; set; }
        [Required]
        [Display(Name = "Углеводы")]
        public int Сarbohydrates { get; set; }
        [Required]
        [Display(Name = "Белки")]
        public int Proteins { get; set; }
        [Required]
        [Display(Name = "Энергетическая ценность")]
        public int EnergyValue { get; set; }
     }
     
    public class Cathegory
    {
        [Required]
        public int? CathegoryId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; } // первое второе салат итд + острое соленое сладкое
        [Display(AutoGenerateField = false)]
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