using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace group_web_application_security.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TableId { get; set; }
        [ForeignKey("TableId")]
        [ValidateNever]
        public Table Table { get; set; }
        public int Count { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ValidateNever]
        public Customer Customer { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
