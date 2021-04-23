using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary.Models;
using Employee.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.Pages.Management
{
    public class ViewModel : PageModel
    {

        public EmployeeData EmployeeData { get; set; }
        public List<SelectListItem> EmployeeTypes { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmployeeTypes = new List<SelectListItem>
            {
                new SelectListItem{Text = "Regular", Value = "1"},
                new SelectListItem{Text = "Contract", Value = "2"}
            };
            EmployeeData = HttpContext.Session.GetEmployees().Where(r => r.ID == id).FirstOrDefault();
            return Page();
        }
     }
}
