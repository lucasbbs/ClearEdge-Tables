using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace group_web_application_security.Models
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
