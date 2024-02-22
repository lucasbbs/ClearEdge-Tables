using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClearEdge_Tables.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string Dimensions { get; set; }
        public int StockQuantity { get; set; }
        [Required]
        public double Weight { get; set; }
        public string? Manufacturer { get; set; }
        public string? Origin_Country { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        [DisplayName("Category Name")]
        public string? Category { get; set; }
    }
}
