using Microsoft.AspNetCore.Mvc.Rendering;

namespace group_web_application_security.Models.ViewModels
{
    public class RoleManagementViewModel
    {
            public Customer ApplicationUser { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
