using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodsProject.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name cannot be empty")]
        [StringLength(20, ErrorMessage = "Category Name must be between 3 and 20 characters", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Food> Foods { get; set; }
    }
}
