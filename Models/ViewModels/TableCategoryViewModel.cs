using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClearEdge_Tables.Models.ViewModels
{
    public class TableCategoryViewModel
    {
        public IEnumerable<Table> Tables { get; set; }
        public SelectList? Categories{ get; set; }
        public string? Category { get; set; }
        public string? SearchString { get; set; }
    }
}

