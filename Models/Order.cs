using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearEdge_Tables.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Order.Id))]
        public string customerId { get; set; }
        [ForeignKey("customerId")]
        [ValidateNever]
        public Customer Customer { get; set; }
        public DateTime order_date { get; set; }
        public DateTime Shipping_Date { get; set; }
        public double total_amount { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
