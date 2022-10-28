using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModel
{
    public class DepartmentListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        public List<SelectListItem> Divisions { get; set; }
    }
}
