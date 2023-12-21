using Castle.Components.DictionaryAdapter.Xml;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Crop //ONE Crop
    {
        [Key]
        public Guid CropId { get; set; }
        [Display(Name = "Name - 1020")]
        public string Name { get; set; }
        [Display(Name = "Seed Density (g)")]
        public int SeedDensity { get; set; }
        [Display(Name = "Soak Hours")]
        public int SoakHours { get; set; } 
        [Display(Name = "Germination Days")]
        public int GerminationDays { get; set; } 
        [Display(Name = "Stack Days")]
        public int StackDays { get; set; }
        [Display(Name = "Black Out Days")]
        public int BlackOutDays { get; set; }
        [Display(Name = "Weighted Days")]
        public int WeightedDays { get; set; }
        [Display(Name = "Total Growth Days")]
        public int TotalGrowthDays { get; set; }

        [Display(Name = "Expected Yield")]
        public int ExpectedYield { get; set; }       
        
    }
}
