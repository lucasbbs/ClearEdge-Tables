using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearEdge_Tables.Models
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
